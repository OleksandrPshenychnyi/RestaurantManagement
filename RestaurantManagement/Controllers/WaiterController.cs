using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Waiter")]
    public class WaiterController : Controller
    {
        ProjectContext db;
        public WaiterController(ProjectContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            //var guests = db.Guests.ToList();
            //var bookings = db.Bookings.ToList();
            return await Task.Run(() => View(db.Guests.ToList()));
           
        }
        //[HttpGet]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null) return RedirectToAction("Index");
        //    ViewBag.GuestId = id;
        //    return await Task.Run(() => View());
        //}


        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CancelConfirmed(int id)
        //{
        //    Guest guest = await db.Guests.FindAsync(id);
            
        //    db.Guests.Remove(guest);
            
        //    await db.SaveChangesAsync();
        //    var table =await db.Tables.FirstOrDefaultAsync(table => guest.TableId == table.TableId);
        //    table.IsAvailable = true;
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        
    }
}
