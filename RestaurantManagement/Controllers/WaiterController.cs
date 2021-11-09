using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Waiter")]
    public class WaiterController : Controller
    {
        ClientContext db;
        public WaiterController(ClientContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Guests.ToList());
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.ClientId = id;
            return View();
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest client = db.Guests.Find(id);
            db.Guests.Remove(client);
            db.SaveChanges();
            var table = db.Tables.FirstOrDefault(table => client.TableId == table.TableId);
            table.IsAvailable = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
