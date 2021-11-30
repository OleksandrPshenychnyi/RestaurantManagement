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
    public class GuestRepository : GenericRepository<Guest>,IGuestRepository
    {
        private ProjectContext db;
        public GuestRepository(ProjectContext context) : base(context)
        {
            db = context;

        }
        public  async Task<IEnumerable<Guest>> GetAsync(int id)
        {
            var getGuest = await db.Guests.Include(guest=> guest.Booking).Where(guest => guest.GuestId == id).ToListAsync();
            return getGuest;
        }
    }
}
