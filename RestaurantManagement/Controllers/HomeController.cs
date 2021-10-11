using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    public class HomeController : Controller
    {
        
        
            ClientContext db;
            public HomeController(ClientContext context)
            {
                db = context;
            }
            public IActionResult Index()
            {
                return View(db.Bookings.ToList());
            }
        [HttpGet]
        public IActionResult ToBook(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.TableId = id;
            return View();
        }
        [HttpPost]
        public string ToBook(Clients client)
        {
            db.Clients.Add(client);
            
            db.SaveChanges();
            return "Thank you, " + client.FirstName + ", for reservation!";
        }
    }
}
