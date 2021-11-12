using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL;
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
        private ITableRepository<Table> tableRepository;
        private IBookingRepository<Booking> bookingRepository;
        private IGuestRepository<Guest> guestRepository;
        UserManager<User> _userManager;

        ClientContext db;
        public BookingController(ClientContext context, UserManager<User> userManager)
        {
            db = context;
            _userManager = userManager;
            this.bookingRepository = new BookingRepository(db);
            this.tableRepository = new TableRepository(db);
            this.guestRepository = new GuestRepository(db);

        }
        [HttpGet]
        public async Task<IActionResult> ToBook(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.TableId = id;
            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> ToBook(Guest guest, int tableId)
        {
            if (!(User.Identity.IsAuthenticated))
            {
                guestRepository.Create(guest);

                //  = db.Guests.Add(guest);
                await db.SaveChangesAsync();

                var bookingObj = new Booking()
                {
                    IsLogged = false,
                    GuestId = guest.GuestId,
                    TableId = tableId
                };
                var savedBooking = db.Bookings.AddAsync(bookingObj).Result.Entity;
                savedBooking.Status = "Reserved";
                // Error???
                //bookingRepository.Update(savedBooking);

                var table = tableRepository.Get(tableId);
                table.IsAvailable = false;
                tableRepository.Update(table);


                return RedirectToAction("ThxPage", guest);

            }
            else return RedirectToAction("ToBookAutorized");

        }
        [HttpGet]
        public async Task<IActionResult> ToBookAutorized(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var selectuser = await db.Users.Where(user => user.Id == userid).SingleOrDefaultAsync();
            ViewBag.User = selectuser;
            ViewBag.TableId = id;

            var selecttable = await db.Tables.Where(table => table.TableId == id).SingleOrDefaultAsync();
            ViewBag.Table = selecttable;

            return await Task.Run(() => View());
        }
        [HttpPost]
        public async Task<IActionResult> ToBookAutorized(int tableId)
        {
            var userid = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var booking = new Booking()
            {
                IsLogged = true,
                User = await _userManager.FindByIdAsync(userid),
                TableId = tableId
            };
            db.Bookings.Add(booking);

            var table = await db.Tables.FirstOrDefaultAsync(table => table.TableId == booking.TableId);
            table.IsAvailable = false;

            var bookingStatus = await db.Bookings.FirstOrDefaultAsync(booking => table.TableId == booking.TableId);
            booking.Status = "Reserved";

            await db.SaveChangesAsync();
            return RedirectToAction("ThxPage");
        }
        public async Task<IActionResult> ThxPage(Guest guest)
        {
            ViewBag.Guest = guest;
            return await Task.Run(() => View());
        }
    }
}
