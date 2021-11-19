
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Services
{
    public class BookingService : IDisposable,IBookingService
    {
        private readonly UserManager<User> _userManager;
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public BookingService(ProjectContext context, UserManager<User> UserManager)
        {
            _userManager = UserManager;
            db = context;
            unitOfWork = new UnitOfWork(db);

        }
        public async Task ToBookAsync(GuestDTO guestDto, int tableId)
        {
            var guestObj = new Guest { TableId = guestDto.TableId,GuestId = guestDto.GuestId,FirstName = guestDto.FirstName,
                SecondName = guestDto.SecondName, PhoneNumber = guestDto.PhoneNumber };
           await unitOfWork.Guests.CreateAsync(guestObj);
            int guestid = guestObj.GuestId ;
            Booking booking = new Booking()
            {
                IsLogged = false,
                GuestId = guestid,
                TableId = tableId,
                Status = "Reserved"
            };
            await unitOfWork.Bookings.CreateAsync(booking);

            var table =await unitOfWork.Tables.GetAsync(tableId);
            table.IsAvailable = false;
           await unitOfWork.Tables.UpdateAsync(table);
        }
        public  async Task ToBookAutorizedAsync(int tableId, User userGet)
        {
            var booking = new Booking()
            {
                IsLogged = true,
                User = userGet,
                TableId = tableId,
                Status = "Reserved"
            };
           await unitOfWork.Bookings.CreateAsync(booking);
            var table = await unitOfWork.Tables.GetAsync(tableId);
            table.IsAvailable = false;
           await  unitOfWork.Tables.UpdateAsync(table);

        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
