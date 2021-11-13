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
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL;

namespace RestaurantManagement.Controllers
{
    public class TableController : Controller
    {
        
         private UnitOfWork unitOfWork;
        UserManager<User> _userManager;
      
        ClientContext db;
            public TableController(ClientContext context, UserManager<User> userManager)
            {
                db = context;
                _userManager = userManager;
            this.unitOfWork = new UnitOfWork(db);
           
        }
            public async Task<IActionResult> Index()
            {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index","Roles");
            }
            else if (User.IsInRole("Waiter"))
            {
                return RedirectToAction("Index", "Waiter");
            }
            //var result = tableRepository.GetTables();
            return await Task.Run(() => View(unitOfWork.TableRepository.GetTables().Where(table=>table.IsAvailable).ToList()));
        }
        
    }
}
