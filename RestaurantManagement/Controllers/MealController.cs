using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.BLL.DTO;
using AutoMapper;
using RestaurantManagement.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RestaurantManagement.Controllers
{
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

        
        public async Task<IActionResult> Index(int? page, string sortOrder, string searchString, string currentFilter, string mealCategory)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.CategorySortParm = sortOrder == "Category" ? "category_desc" : "Category";
            ViewBag.CurrentSort = sortOrder;
            var mealGet = await mealService.GetMealsAsync();
            var category = mealGet.OrderBy(m => m.Category).Select(m => m.Category);
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                mealGet = mealGet.Where(m => m.MealName!.Contains(searchString));
            }

            
            List<MealDTO> result = mealGet.ToList();
            


            switch (sortOrder)
            {
                case "name_desc":
                    mealGet = mealGet.OrderByDescending(m => m.MealName);
                    break;
                case "Category":
                    mealGet = mealGet.OrderBy(m => m.Category);
                    break;
                case "category_desc":
                    mealGet = mealGet.OrderByDescending(p => p.Category);
                    break;
                default:
                    mealGet = mealGet.OrderBy(m => m.UnitPrice);
                    break;
            }
            
            var mappedMeal = _mapper.Map<List<MealViewModel>>(result);
            
            return View(mappedMeal.ToPagedList(pageNumber,pageSize));
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealId,MealName,Description,Category,ImagePath,ImageFile,UnitPrice")] MealDTO meal)
        {
            if (ModelState.IsValid)
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
        public async Task<IActionResult> Edit(int id, [Bind("MealId,MealName,Description,Category,ImagePath,ImageFile,UnitPrice")] MealDTO meal)
        {
            if (id != meal.MealId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                        string wwwrootPath = _hostEnvironment.WebRootPath;
                        string FileName = Path.GetFileName(meal.ImageFile.FileName);
                        string extension = Path.GetExtension(meal.ImageFile.FileName);
                        meal.ImagePath = FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
                        string path = Path.Combine(wwwrootPath + "/Images/" + FileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await meal.ImageFile.CopyToAsync(fileStream);
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
