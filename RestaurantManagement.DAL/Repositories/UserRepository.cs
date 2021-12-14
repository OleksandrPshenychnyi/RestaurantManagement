using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ProjectContext db;

        public UserRepository(ProjectContext context)
        {
            db = context;

        }

        public async Task<IEnumerable<Booking>> GetOneBookingForUser(string id)
        {
            var getBooking = await db.Bookings.Include(booking => booking.Table).
                Include(booking => booking.Booking_Meals).
                ThenInclude(booking => booking.Meal).
                Where(booking => booking.User.Id == id).ToListAsync();
            return getBooking;
        }
    }
}
