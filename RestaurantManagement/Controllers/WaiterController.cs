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
        IBookingService bookingService;
        IGuestService guestService;
        ProjectContext db;
        private readonly UserManager<User> _userManager;
        public WaiterController(ProjectContext context, IBookingService servB, IGuestService servG, UserManager<User> UserManager)
        {
            _userManager = UserManager;
            bookingService = servB;
            db = context;
            guestService = servG;
        }
        public async Task<IActionResult> Index()
        {
            
            var activeBookings = await bookingService.GetBookingsAsync("Reserved",false);
            var users = activeBookings.Select(booking => booking.User);
            ViewBag.User = users;
            var activeBookings1 = await bookingService.GetBookingsAsync("Reserved",true);
            var guests = activeBookings1.Select(booking => booking.Guest).ToList();
            ViewBag.Guest = guests;


            return await Task.Run(() => View());



        }
        public async Task<IActionResult> Archive()
        {

            var activeBookings = await bookingService.GetBookingsAsync("Closed",false);
            var users = activeBookings.Select(booking => booking.User);
            ViewBag.User = users;
            var activeBookings1 = await bookingService.GetBookingsAsync("Closed",true);
            var guests = activeBookings1.Select(booking => booking.Guest);
            ViewBag.Guest = guests;


            return await Task.Run(() => View());



        }
        [HttpGet]
        public async Task<IActionResult> CloseGuestAsync(int id)
        {


            //if (id == null) return RedirectToAction("Index");
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


            //if (id == null) return RedirectToAction("Index");

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

    }
}
