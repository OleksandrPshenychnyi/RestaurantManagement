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
using X.PagedList;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> TableList(int? page)
        {
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            var tableGet = await tableService.GetTablesListAsync();
            var mappedTable = _mapper.Map<List<TableViewModel>>(tableGet);

            return await Task.Run(() => View( mappedTable.ToPagedList(pageNumber, pageSize)));
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
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var tableGet = await tableService.GetTableAsync(id);
            var mappedTable = _mapper.Map<MealViewModel>(tableGet);
            if (mappedTable == null)
            {
                return NotFound();
            }

            return View(mappedTable);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TableId,IsAvaliable,TableNumber,Capacity,HallPlacing,TablePrice,TableDiscount")] TableDTO table)
        {
            if (ModelState.IsValid)
            {
               
                await tableService.CreateTableAsync(table);
                return RedirectToAction(nameof(Index));
            }
            var mappedTable = _mapper.Map<TableViewModel>(table);
            return View(mappedTable);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var table = await tableService.GetTableAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            var tableGet = await tableService.GetTablesListAsync();
            
           
            var mappedTable = _mapper.Map<TableViewModel>(table);
            return View(mappedTable);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TableId,IsAvailable,TableNumber,Capacity,HallPlacing,TablePrice,TableDiscount")] TableDTO table)
        {
            if (id != table.TableId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                  
                        await tableService.UpdateTableAsync(table);
     
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await TableExists(table.TableId)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("TableList", "Table");
            }
            var mappedTable = _mapper.Map<TableViewModel>(table);
            return View(mappedTable);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var table = await tableService.GetTableAsync(id);
            if (table == null)
            {
                return NotFound();
            }
            var mappedTable = _mapper.Map<TableViewModel>(table);
            return View(mappedTable);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await tableService.DeleteTableAsync(id);
            return RedirectToAction("TableList", "Table");
        }

        private async Task<bool> TableExists(int id)
        {
            return await tableService.TableExists(id);

        }
    }
}
