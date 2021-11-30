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
        
        public BookingRepository(ProjectContext context):base(context)
        {
            db = context;
          
        }
        public async Task<IEnumerable<Booking>> GetAllUserBookingAsync()
        {

            return await db.Bookings.Include(booking => booking.User).ToListAsync();
        }
        public  async Task<IEnumerable<Booking>> GetAllGuestBookingAsync()
        {

            return await db.Bookings.Include(booking => booking.Guest).ToListAsync();
        }
        public async Task<IEnumerable<Booking>> GetGuestBookingAsync(int guestId)
        {
            var getBooking = await db.Bookings.Include(booking => booking.Table).Include(booking => booking.Guest).
                Where(booking => booking.GuestId == guestId).ToListAsync();


            return getBooking;
        }
        public async Task<IEnumerable<Booking>> GetUserBookingAsync(string userId)
        {
            var getBooking = await db.Bookings.Include(booking => booking.Table).
                Where(booking => booking.User.Id == userId).ToListAsync();


            return getBooking;
        }

    }
}
