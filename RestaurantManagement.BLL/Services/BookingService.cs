
using AutoMapper;
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
        public async Task ToBookAsync(GuestDTO guestDTO, int tableId)
        {
            var guestObj = new Guest { TableId = guestDTO.TableId,GuestId = guestDTO.GuestId,FirstName = guestDTO.FirstName,
                SecondName = guestDTO.SecondName, PhoneNumber = guestDTO.PhoneNumber, Served=false};
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
            //decimal disc = new Discount(0.1m).GetDiscountedPrice(Table.Price);
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
        
        public async Task CloseReservation(Guest guest, int tableId)
        {
            guest.Served = true;
            await unitOfWork.Guests.UpdateAsync(guest);

            var tableGet = await unitOfWork.Tables.GetAsync(tableId);
            tableGet.IsAvailable = true;
            await unitOfWork.Tables.UpdateAsync(tableGet);
           
            var bookingObj = db.Bookings.FirstOrDefault(booking => booking.GuestId == guest.GuestId);
            
            bookingObj.Status = "Closed";
            await unitOfWork.Bookings.SaveAsync();

            
        }
        public IEnumerable<Booking> GetAllBookings()
        {
            
            return unitOfWork.Bookings.GetAll();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
