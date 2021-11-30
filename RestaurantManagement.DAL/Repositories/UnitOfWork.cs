
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using RestaurantManagement.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext db;
        public UnitOfWork(ProjectContext db)
        {
            this.db = db;
        }

        
        private GenericRepository<Table> tableRepository;
        private GuestRepository guestRepository;
        //private GenericRepository<Guest> guestRepository;
        private GenericRepository<User> userRepository;
        private BookingRepository bookingRepository;
        public IGenericRepository<Table> Tables
        {
            get
            {

                if (this.tableRepository == null)
                {
                    this.tableRepository = new GenericRepository<Table>(db);
                }
                return tableRepository;
            }
        }
        //public IGenericRepository<Booking> Bookings
        //{
        //    get
        //    {

        //        if (this.bookingRepository == null)
        //        {
        //            this.bookingRepository = new GenericRepository<Booking>(db);
        //        }
        //        return bookingRepository;
        //    }
        //}
        //public IGenericRepository<Guest> Guests
        //{
        //    get
        //    {

        //        if (this.guestRepository == null)
        //        {
        //            this.guestRepository = new GenericRepository<Guest>(db);
        //        }
        //        return guestRepository;
        //    }
        //}
        public IGenericRepository<User> Users
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(db);
                }
                return userRepository;
            }
        }
        public IBookingRepository Bookings
        {
            get
            {

                if (this.bookingRepository == null)
                {
                    this.bookingRepository = new BookingRepository(db);
                }
                return bookingRepository;
            }
        }
        public IGuestRepository Guests
        {
            get
            {

                if (this.guestRepository == null)
                {
                    this.guestRepository = new GuestRepository(db);
                }
                return guestRepository;
            }
        }
        public  void SaveAsync()
        {
            db.SaveChangesAsync();
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
