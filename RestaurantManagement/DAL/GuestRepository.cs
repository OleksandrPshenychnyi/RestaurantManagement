using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class GuestRepository : IDisposable, IGuestRepository<Guest>
    {
        private ClientContext db;

        public GuestRepository(ClientContext context)
        {
            this.db = context;
        }

        public IEnumerable<Guest> GetGuests()
        {

            return db.Guests.ToList();
        }

        public Guest Get(int id)
        {

            return db.Guests.Find(id);
        }

        public void Create(Guest guest)
        {
            db.Guests.Add(guest);
        }

        public void Update(Guest guest)
        {
            db.Entry(guest).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Guest guest = db.Guests.Find(id);
            if (guest != null)
                db.Guests.Remove(guest);
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
