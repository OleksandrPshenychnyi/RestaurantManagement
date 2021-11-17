using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class BookingRepository : IDisposable, IBookingRepository
    {
        private ProjectContext db;

        public BookingRepository(ProjectContext context)
        {
            this.db = context;
        }

        public async Task<IEnumerable<Booking>> GetBookingsAsync()
        {

            return await db.Bookings.ToListAsync();
        }

        public async Task<Booking> GetAsync(int id)
        { 

            return await db.Bookings.FindAsync(id);
        }

        public async void CreateAsync(Booking booking)
        {
            await db.Bookings.AddAsync(booking);
        }

        public async void UpdateAsync(Booking booking)
        {
             db.Entry(booking).State = EntityState.Modified;
            
        }

        public async void DeleteAsync(int id)
        {
            Booking booking =await db.Bookings.FindAsync(id);
            if (booking != null)
                db.Bookings.Remove(booking);
        }

        public async void SaveAsync()
        {
          await  db.SaveChangesAsync();
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
