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
        private readonly IMapper _mapper;
        ITableService tableService;
        public TableController(ITableService serv, IMapper mapper)
            {
            tableService = serv;
            _mapper = mapper;
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
            
            IEnumerable<TableDTO> tableDtos = await tableService.GetTablesAsync();
            var mappedTables = _mapper.Map<List<TableViewModel>>(tableDtos);
            return await Task.Run(() => View(mappedTables));
        }
        
    }
}
