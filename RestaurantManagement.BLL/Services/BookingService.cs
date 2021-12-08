
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
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public BookingService(ProjectContext context, UserManager<User> UserManager, IMapper mapper)
        {
            _userManager = UserManager;
            db = context;
            unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }
        public async Task ToBookAsync(GuestDTO guestDTO, int tableId, IEnumerable<int> mealId, IEnumerable<int> amount)
        {
            var guestObj = _mapper.Map<Guest>(guestDTO);
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
            var bookingId = booking.Id;
            await unitOfWork.Bookings_Meals.CreateAsync(bookingId, mealId,amount);
            var table =await unitOfWork.Tables.GetAsync(tableId);
            table.IsAvailable = false;
           await unitOfWork.Tables.UpdateAsync(table);
        }
       
        public  async Task ToBookAutorizedAsync(int tableId, User userGet, IEnumerable<int> mealId, IEnumerable<int> amount)
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
            var bookingId = booking.Id;
            await unitOfWork.Bookings_Meals.CreateAsync(bookingId, mealId, amount);
            var table = await unitOfWork.Tables.GetAsync(tableId);
            table.IsAvailable = false;
           await  unitOfWork.Tables.UpdateAsync(table);

        }
        
        public async Task CloseReservationGuest(int guestId, int tableId)
        {
            var bookingGet = await unitOfWork.Bookings.GetGuestBookingAsync(guestId);
            var bookingGetGuest = bookingGet.FirstOrDefault(booking => booking.GuestId == guestId);
            bookingGetGuest.Status = "Closed";
            await unitOfWork.Bookings.SaveAsync();
            bookingGetGuest.Guest.Served= true;
            await unitOfWork.Guests.SaveAsync();
            bookingGetGuest.Table.IsAvailable = true;
            await unitOfWork.Tables.SaveAsync();

        }
        public async Task CloseReservationUser(string userId, int tableId)
        {
            var bookingGet = await unitOfWork.Bookings.GetUserBookingAsync(userId);
            var bookingGetUser = bookingGet.FirstOrDefault(booking => booking.TableId == tableId);
            bookingGetUser.Status = "Closed";
            await unitOfWork.Bookings.SaveAsync();
            bookingGetUser.Table.IsAvailable = true;
            await unitOfWork.Tables.SaveAsync();

        }
        public async Task<IEnumerable<BookingDTO>> GetBookingsAsync(string status, bool isNull)
        {
            if (status != "Reserved" && status != "Closed")
            {
                throw new InvalidOperationException("Status not found!");
            }
            else if (isNull == false)
            {
                var activeBookingsUser = await unitOfWork.Bookings.GetAllUserBookingAsync();
                var activeBookingsFilteredUser = activeBookingsUser.Where(booking => booking.Status == status && booking.IsLogged == true);
                var mappedActiveBookingsUser = _mapper.Map<List<BookingDTO>>(activeBookingsFilteredUser);
                return mappedActiveBookingsUser;
            }
            else  
            {
                var activeBookingsGuest = await unitOfWork.Bookings.GetAllGuestBookingAsync();
                var activeBookingsFilteredGuest = activeBookingsGuest.Where(booking => booking.Status == status && booking.IsLogged == false); 
                
                var mappedActiveBookingsGuest = _mapper.Map<List<BookingDTO>>(activeBookingsFilteredGuest);
                return mappedActiveBookingsGuest;
            }  

        }
        public async Task<IEnumerable<Booking>> GetOneBookingGuestAsync(int? guestId)
        {
            var getBooking = await unitOfWork.Bookings.GetGuestBookingAsync(guestId);
      
           return getBooking;
        }

        public async Task<IEnumerable<Booking>> GetOneBookingUserAsync(string userId)
        {
            var getBooking = await unitOfWork.Bookings.GetUserBookingAsync(userId);

            return getBooking;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
