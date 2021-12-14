using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.BLL;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using X.PagedList;

namespace RestaurantManagement.Controllers
{
    public class BookingController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        IBookingService bookingService;
        IMealService mealService;
        ITableService tableService;
        public BookingController(IBookingService serv, ProjectContext projectContext, UserManager<User> UserManager, IMapper mapper, IMealService servM, ITableService servT)
        {
            _userManager = UserManager;
            bookingService = serv;
            db = projectContext;
            _mapper = mapper;
            mealService = servM;
            tableService = servT;
        }
        ProjectContext db;
        [HttpGet]
        public async Task<IActionResult> ToBook(int? id)
        {
            if (id == null) return RedirectToAction("Index");


            ViewBag.TableId = id;

            var mealGet = await mealService.GetMealsAsync();
            var selecttable = await tableService.GetOneTableAsync(id);
            ViewBag.Table = selecttable;
            ViewBag.Meal = mealGet;

            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> ToBookAsync(GuestViewModel guest, int tableId, IEnumerable<int> mealId, IEnumerable<int> amount)
        {
            if (!(User.Identity.IsAuthenticated))
            {
                if (ModelState.IsValid)
                {
                    var mappedGuest = _mapper.Map<GuestDTO>(guest);
                    await bookingService.ToBookAsync(mappedGuest, tableId, mealId, amount);
                    return RedirectToAction("ThxPage");
                }
                return View(guest);
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

            var selecttable = await tableService.GetOneTableAsync(id);
            var getTable = selecttable.FirstOrDefault();
            ViewBag.TableDiscount = getTable.TableDiscount;
            ViewBag.Table = selecttable;
            var mealGet = await mealService.GetMealsAsync();
            ViewBag.Meal = mealGet;
            return await Task.Run(() => View());
        }
        [HttpPost]

        public async Task<IActionResult> ToBookAutorizedAsync(UserViewModel userGet, int tableId, IEnumerable<int> mealId, IEnumerable<int> amount, decimal tableDiscount, DateTime dateTime)
        {
            string userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            User user = await _userManager.FindByIdAsync(userid);
            var getDate = userGet.ReservationDate;
            var getDateDefault = getDate;

            await bookingService.ToBookAutorizedAsync(tableId, user, mealId, amount, tableDiscount, getDateDefault);

            return RedirectToAction("ThxPage");
        }
        public async Task<IActionResult> ThxPage()
        {
            return await Task.Run(() => View());
        }
    }
}
