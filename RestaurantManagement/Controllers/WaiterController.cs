using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.BLL;
using AutoMapper;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL.Enteties;

namespace RestaurantManagement.Controllers
{
    //[Authorize(Roles = "Waiter")]
    public class WaiterController : Controller
    {
        IBookingService bookingService;
        IGuestService guestService;
        ProjectContext db;
        public WaiterController(ProjectContext context, IBookingService servB, IGuestService servG)
        {
            bookingService = servB;
            db = context;
            guestService = servG;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Guest> guestDtos = guestService.GetAllGuestsAsync().ToList();
            var mapperG = new MapperConfiguration(cfg => cfg.CreateMap<Guest, GuestViewModel>()).CreateMapper();
            var guests = mapperG.Map<IEnumerable<Guest>, List<GuestViewModel>>(guestDtos);
            ViewBag.Guest = guests;
            
            
            return await Task.Run(() => View());



        }
        [HttpGet]
        public async Task<IActionResult> Close(int id)
        {
            
            
            //if (id == null) return RedirectToAction("Index");
            
           var guestGet =  await guestService.GetGuestAsync(id);
            var tableId = guestGet.TableId;
            
            ViewBag.TableId = tableId;
            ViewBag.GuestId = id;
           
            return await Task.Run(() => View());
        }


        [HttpPost, ActionName("Close")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CloseConfirmed(int guestId,  int tableId)
        {
            Guest guestGet = await guestService.GetGuestAsync(guestId);
            
            await bookingService.CloseReservation(guestGet, tableId);
            
            return RedirectToAction("Index");

        }
    }
}
