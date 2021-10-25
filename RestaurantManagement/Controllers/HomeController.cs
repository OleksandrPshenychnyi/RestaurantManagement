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
            var _avaliableTables = db.Tables.Where(table => table.IsAvailable).ToList();
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
        public IActionResult ToBook(Client client)
        {
            db.Clients.Add(client);
            
            db.SaveChanges();
            var table = db.Tables.FirstOrDefault(table => table.TableId == client.TableId);
            table.IsAvailable = false;
            db.SaveChanges();
            return RedirectToAction("ThxPage", client);

        }
        public IActionResult ThxPage(Client client)
        {
            ViewBag.Clients = client; 
            return View();
        }
    }
}
