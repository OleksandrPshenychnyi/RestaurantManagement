using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Repositories
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        private ProjectContext db;
        
        public BookingRepository( ProjectContext context):base(context)
        {
            db = context;
           
        }
        public async Task<IEnumerable<Booking>> GetAllUserBookingAsync()
        {

            return await db.Bookings.Include(booking => booking.User).Include(booking => booking.Booking_Meals)
                .ThenInclude(booking => booking.Meal).ToListAsync();
        }
        public  async Task<IEnumerable<Booking>> GetAllGuestBookingAsync()
        {
            var bookingG = await db.Bookings.Include(booking => booking.Guest).Include(booking => booking.Booking_Meals)
                .ThenInclude(booking => booking.Meal).ToListAsync();

            return bookingG;
        }
        public async Task<IEnumerable<Booking>> GetGuestBookingAsync(int? guestId)
        {
            var getBooking = await db.Bookings.Include(booking => booking.Table).Include(booking => booking.Guest).
                Where(booking => booking.GuestId == guestId).ToListAsync();


            return getBooking;
        }
#nullable enable
        public async Task<IEnumerable<Booking>> GetUserBookingAsync(string? userId)
        {
            var getBooking = await db.Bookings.Include(booking => booking.Table).
                Where(booking => booking.User.Id == userId && booking.Status == "Reserved").ToListAsync();


            return getBooking;
        }
        public async Task<IEnumerable<Booking>> GetBookingForMealAsync(int? id)
        {
            var getBookingMeal = await db.Bookings.Include(booking => booking.Booking_Meals).ThenInclude(booking => booking.Meal)
                .Where(booking => booking.Id == id).ToListAsync();
            return getBookingMeal;
        }
    }
}
