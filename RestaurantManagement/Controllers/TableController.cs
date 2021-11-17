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
using RestaurantManagement.DAL.EF;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.BLL;
using AutoMapper;

namespace RestaurantManagement.Controllers
{
    public class TableController : Controller
    {

        ITable tableService;
        public TableController(ITable serv)
            {
            tableService = serv;

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
            IEnumerable<TableDTO> tableDtos =  tableService.GetTablesAsync().Where(table => table.IsAvailable).ToList();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TableDTO, TableViewModel>()).CreateMapper();
            var tables = mapper.Map<IEnumerable<TableDTO>, List<TableViewModel>>(tableDtos);
            return await Task.Run(() => View(tables));
        }
        
    }
}
