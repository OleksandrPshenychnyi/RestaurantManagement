using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class GuestRepository : IDisposable, IGuestRepository
    {
        private ProjectContext db;

        public GuestRepository(ProjectContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Guest>> GetGuestsAsync()
        {

            return await db.Guests.ToListAsync();
        }

        public async Task<Guest> GetAsync(int id)
        {

            return await db.Guests.FindAsync(id);
        }

        public async void CreateAsync(Guest guest)
        {
            await db.Guests.AddAsync(guest);
        }

        public async void UpdateAsync(Guest guest)
        {
            db.Entry(guest).State = EntityState.Modified;

        }

        public async void DeleteAsync(int id)
        {
            Guest guest = await db.Guests.FindAsync(id);
            if (guest != null)
                db.Guests.Remove(guest);
        }

        public async void SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
