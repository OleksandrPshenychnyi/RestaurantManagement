using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.BLL.DTO;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MealController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostEnvironment;
        IMealService mealService;
        private readonly UserManager<User> _userManager;
        private readonly ProjectContext db;
        public MealController(ProjectContext projectContext, UserManager<User> UserManager, IMealService servM, IWebHostEnvironment hostEnvironment, IMapper mapper)
        {
            _userManager = UserManager;
            db = projectContext;
            mealService = servM;
            _hostEnvironment = hostEnvironment;
            _mapper = mapper;
        }

        
        public async Task<IActionResult> Index(int? page, string searchString)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var mealGet = await mealService.GetMealsAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                mealGet = mealGet.Where(s => s.MealName.Contains(searchString)
                                       || s.Category.Contains(searchString));
            }
            List<MealDTO> listOfMeals = mealGet.ToList();
            var mappedMeal = _mapper.Map<List<MealViewModel>>(listOfMeals);

            return View(mappedMeal.ToPagedList(pageNumber, pageSize));
        }


        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var mealGet = await mealService.GetOneMealAsync(id);
            var mappedMeal = _mapper.Map<MealViewModel>(mealGet);
            if (mappedMeal == null)
            {
                return NotFound();
            }

            return View(mappedMeal);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        public async Task ImageCreate(MealDTO meal)
        {
            string wwwrootPath = _hostEnvironment.WebRootPath;
            string FileName = Path.GetFileNameWithoutExtension(meal.ImageFile.FileName);
            string extension = Path.GetExtension(meal.ImageFile.FileName);
            meal.ImagePath = FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
            string path = Path.Combine(wwwrootPath + "/Images/" + FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await meal.ImageFile.CopyToAsync(fileStream);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealId,MealName,Description,Category,ImagePath,ImageFile,UnitPrice")] MealDTO meal)
        {
            if (ModelState.IsValid)
            {

                await ImageCreate(meal);
                await mealService.CreateMealAsync(meal);
                return RedirectToAction(nameof(Index));
            }
            var mappedMeal = _mapper.Map<MealViewModel>(meal);
            return View(mappedMeal);
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
            var mappedMeal = _mapper.Map<MealViewModel>(meal);
            return View(mappedMeal);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealId,MealName,Description,Category,ImagePath,UnitPrice")] MealDTO meal)
        {
            if (id != meal.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (meal.ImageFile != null)
                    {
                        await ImageCreate(meal);
                    }
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
            var mappedMeal = _mapper.Map<MealViewModel>(meal);
            return View(mappedMeal);
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
            var mappedMeal = _mapper.Map<MealViewModel>(meal);
            return View(mappedMeal);
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
