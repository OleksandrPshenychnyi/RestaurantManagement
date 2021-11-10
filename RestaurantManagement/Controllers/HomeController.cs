using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace RestaurantManagement.Controllers
{
    public class HomeController : Controller
    {
        UserManager<User> _userManager;
      
        ClientContext db;
            public HomeController(ClientContext context, UserManager<User> userManager)
            {
                db = context;
                _userManager = userManager;
        }
            public IActionResult Index()
            {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index","Roles");
            }
            else if (User.IsInRole("Waiter"))
            {
                return RedirectToAction("Index", "Waiter");
            }
            var _avaliableTables =  db.Tables.Where(table => table.IsAvailable).ToList();
                return View(_avaliableTables);
            }
        [HttpGet]
        public IActionResult ToBook(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.TableId = id;
            return View();
        }
        [HttpPost]
        public IActionResult ToBook(Guest guest, int tableId)
        {
            if (!(User.Identity.IsAuthenticated))
            {
                var guestId = db.Guests.Add(guest);
                db.SaveChanges();

                var booking = new Booking()
                {
                    IsLogged = false,
                    GuestId = guestId.Entity.GuestId,
                    TableId = tableId
                };
                db.Bookings.Add(booking);
                var table = db.Tables.FirstOrDefault(table => table.TableId == guest.TableId);
                table.IsAvailable = false;
                db.SaveChanges();
                return RedirectToAction("ThxPage", guest);

            }
            else return RedirectToAction("ToBookAutorized");

        }
        [HttpGet]
        public  IActionResult ToBookAutorized(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            //var UserId = await _userManager.FindByIdAsync(userid);
            var selectuser = from User in db.Users
                             where User.Id == userid
                             select User;
            ViewBag.User = selectuser;
            ViewBag.TableId = id;

            var selecttable = from Table in db.Tables
                              where Table.TableId == id
                              select Table;

            ViewBag.Table = selecttable;

            return View(); ;
        }
        [HttpPost]
        public async Task<IActionResult> ToBookAutorized( int tableId)
        {
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var booking = new Booking()
            {
                IsLogged = true,
                User = await _userManager.FindByIdAsync(userid),
                TableId = tableId
            };
            db.Bookings.Add(booking);
            var table = db.Tables.FirstOrDefault(table => table.TableId == booking.TableId);
            table.IsAvailable = false;
            db.SaveChanges();
            return RedirectToAction("ThxPage");
        }
        public IActionResult ThxPage(Guest guest)
        {
            ViewBag.Guest = guest;
            return View();
        }
    }
}
