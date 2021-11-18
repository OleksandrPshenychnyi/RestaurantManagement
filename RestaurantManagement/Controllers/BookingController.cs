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
        IBookingService bookingService;
        public BookingController(IBookingService serv, ProjectContext projectContext, UserManager<User> UserManager)
        {
            _userManager = UserManager;
            bookingService = serv;
            db = projectContext;

        }
        ProjectContext db;
        [HttpGet]
        public async Task<IActionResult> ToBook(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.TableId = id;
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> ToBookAsync(GuestViewModel guest, int tableId)
        {
            if (!(User.Identity.IsAuthenticated))
            {
                var guestObj = new GuestDTO { TableId = guest.TableId, FirstName = guest.FirstName, SecondName = guest.SecondName, PhoneNumber = guest.PhoneNumber };
                await bookingService.ToBookAsync(guestObj, tableId);
                return RedirectToAction("ThxPage", guest);

            }
            else return RedirectToAction("ToBookAutorized");

        }
        [HttpGet]
        public async Task<IActionResult> ToBookAutorized(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var selectuser = await db.Users.Where(user => user.Id == userid).ToListAsync();
            ViewBag.User = selectuser;
            ViewBag.TableId = id;

            var selecttable = await db.Tables.Where(table => table.TableId == id).ToListAsync();
            ViewBag.Table = selecttable;

            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> ToBookAutorizedAsync(int tableId, string userid)
        {
             userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
           User userGet= await _userManager.FindByIdAsync(userid);
            bookingService.ToBookAutorizedAsync(tableId, userGet);
            //var booking = new Booking()
            //{
            //    IsLogged = true,
            //    User = await _userManager.FindByIdAsync(userid),
            //    TableId = tableId
            //};
            //db.Bookings.Add(booking);

            //var table = await db.Tables.FirstOrDefaultAsync(table => table.TableId == booking.TableId);
            //table.IsAvailable = false;

            //var bookingStatus = await db.Bookings.FirstOrDefaultAsync(booking => table.TableId == booking.TableId);
            //booking.Status = "Reserved";

            //await db.SaveChangesAsync();
            return RedirectToAction("ThxPage");
        }
        public async Task<IActionResult> ThxPage(Guest guest)
        {
            ViewBag.Guest = guest;
            return await Task.Run(() => View());
        }
    }
}
