using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.BLL;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        IBookingService bookingService;
        IMealService mealService;
        public BookingController(IBookingService serv, ProjectContext projectContext, UserManager<User> UserManager, IMapper mapper, IMealService servM)
        {
            _userManager = UserManager;
            bookingService = serv;
            db = projectContext;
            _mapper = mapper;
            mealService = servM;
        }
        ProjectContext db;
        [HttpGet]
        public async Task<IActionResult> ToBook(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.TableId = id;
            var mealGet = await mealService.GetMealsAsync();
            ViewBag.Meal = mealGet;
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> ToBookAsync(GuestViewModel guest, int tableId, IEnumerable<int> mealId)
        {
            if (!(User.Identity.IsAuthenticated))
            {
                var mappedGuest = _mapper.Map<GuestDTO>(guest);
                await bookingService.ToBookAsync(mappedGuest, tableId, mealId);
                return RedirectToAction("ThxPage", guest);

            }
            else return RedirectToAction("ToBookAutorized");

        }
        [HttpGet]
        public async Task<IActionResult> ToBookAutorizedAsync(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var userId = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var selectuser = await db.Users.Where(user => user.Id == userId).ToListAsync();
            ViewBag.User = selectuser;
            ViewBag.TableId = id;

            var selecttable = await db.Tables.Where(table => table.TableId == id).ToListAsync();
            ViewBag.Table = selecttable;
            var mealGet = await mealService.GetMealsAsync();
            ViewBag.Meal = mealGet;
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> ToBookAutorizedAsync(int tableId, IEnumerable<int> mealId)
        {
           string userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           User userGet= await _userManager.FindByIdAsync(userid);
           await  bookingService.ToBookAutorizedAsync(tableId, userGet,mealId);
            
            return RedirectToAction("ThxPage");
        }
        public async Task<IActionResult> ThxPage(Guest guest)
        {
            ViewBag.Guest = guest;
            return await Task.Run(() => View());
        }
    }
}
