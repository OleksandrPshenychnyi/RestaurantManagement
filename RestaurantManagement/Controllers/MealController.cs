using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class MealController : Controller
    {
        IMealService mealService;
        private readonly UserManager<User> _userManager;
        private readonly ProjectContext db;
        public MealController(ProjectContext projectContext, UserManager<User> UserManager, IMealService servM)
        {
            _userManager = UserManager;
            db = projectContext;
            mealService = servM;
        }
       
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var mealGet = await mealService.GetMealsAsync();
            return View(mealGet);
        }

       
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mealGet = await mealService.GetOneMealAsync(id); 
            if (mealGet == null)
            {
                return NotFound();
            }

            return View(mealGet);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealId,MealName,Description,ImagePath,UnitPrice")] Meal meal)
        {
            if (ModelState.IsValid)
            {
                await mealService.CreateMealAsync(meal);
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var meal = await mealService.GetOneMealAsync(id);
            if (meal == null)
            {
                return NotFound();
            }
            return View(meal);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealId,MealName,Description,ImagePath,UnitPrice")] Meal meal)
        {
            if (id != meal.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await mealService.UpdateMealAsync(meal);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await MealExists(meal.MealId)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(meal);
        }

       
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var meal = await mealService.GetOneMealAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            return View(meal);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await mealService.DeleteMealAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> MealExists(int id)
        {
            return await mealService.MealExists(id);
            
        }

    }
}
