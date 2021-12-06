using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.BLL;
using AutoMapper;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL.Enteties;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace RestaurantManagement.Controllers
{
    //[Authorize(Roles = "Waiter")]
    public class WaiterController : Controller
    {
        private readonly IMapper _mapper;
        IBookingService bookingService;
        IGuestService guestService;
        IMealService mealService;
        ProjectContext db;
        private readonly UserManager<User> _userManager;
        public WaiterController(ProjectContext context, IBookingService servB, IGuestService servG,IMealService servM, UserManager<User> UserManager, IMapper mapper)
        {
            mealService = servM;
            _userManager = UserManager;
            bookingService = servB;
            db = context;
            guestService = servG;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var bookingDtosUser = await bookingService.GetBookingsAsync("Reserved", false);
            ViewBag.User = bookingDtosUser;
           
            IEnumerable<BookingDTO> bookingDtosGuest = await bookingService.GetBookingsAsync("Reserved", true);
            ViewBag.Guest = bookingDtosGuest;


            return await Task.Run(() => View());



        }
        public async Task<IActionResult> Archive()
        {

            var closedBookingsUser = await bookingService.GetBookingsAsync("Closed",false);
            ViewBag.User = closedBookingsUser;
            var closedBookingsGuest = await bookingService.GetBookingsAsync("Closed",true);
            ViewBag.Guest = closedBookingsGuest;


            return await Task.Run(() => View());



        }
        [HttpGet]
        public async Task<IActionResult> CloseGuestAsync(int? id)
        {


            if (id == null) return RedirectToAction("Index");
            var getBookingGuest = await bookingService.GetOneBookingGuestAsync(id);

            
            ViewBag.GuestId = id;

            var tableId = getBookingGuest.Select(tableId=> tableId.TableId).FirstOrDefault().ToString();
            ViewBag.TableId = tableId;


            return await Task.Run(() => View());
        }
        [HttpPost, ActionName("CloseGuest")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CloseConfirmedGuestAsync(int guestId, int tableId)
        {

            await bookingService.CloseReservationGuest(guestId, tableId);

            return RedirectToAction("Index");

        }
        [HttpGet]

        public async Task<IActionResult> CloseUserAsync(string id)
        {


            if (id == null) return RedirectToAction("Index");

            var getBookingUser = await bookingService.GetOneBookingUserAsync(id);
            
            ViewBag.UserId = id;

            var tableId = getBookingUser.Select(tableId => tableId.TableId).FirstOrDefault().ToString();
            ViewBag.TableId = tableId;

            return await Task.Run(() => View());
        }
        [HttpPost, ActionName("CloseUser")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CloseConfirmedUserAsync(string userId, int tableId)
        {

            await bookingService.CloseReservationUser(userId, tableId);

            return RedirectToAction("Index");

        }
        [HttpGet]

        public async Task<IActionResult> MealsReadyAsync(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var getBookingMeal = await mealService.GetBookingForMeals(id);
           
            ViewBag.BookingId = id;
            ViewBag.BookingMeals = getBookingMeal;
            var mealGet = await mealService.GetMealsAsync();
            ViewBag.Meal = mealGet;

            return await Task.Run(() => View());
        }
        [HttpPost, ActionName("MealsReadyAsync")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MealsReadyAsync(int id, IEnumerable<int> mealId)
        {

             await mealService.CreateMealAsync(id, mealId);
            return RedirectToAction("Index");

        }
    }
}
