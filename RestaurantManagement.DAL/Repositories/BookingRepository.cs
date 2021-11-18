using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class BookingRepository :  IGenericRepository<Booking>, IDisposable
    {
        private ProjectContext db;

        public BookingRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Booking> GetAll()
        {

            return db.Bookings.ToList();
        }

        public  Booking Get(int id)
        { 

            return  db.Bookings.Find(id);
        }

        public void Create(Booking booking)
        {
           db.Bookings.Add(booking);
          
        }

        public  void Update(Booking booking)
        {
             db.Entry(booking).State = EntityState.Modified;
           
        }

        public void Delete(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking != null)
                db.Bookings.Remove(booking);
           
        }

        public void Save()
        {
            db.SaveChanges();
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
