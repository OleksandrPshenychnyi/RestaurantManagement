
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class UnitOfWork : IDisposable
    {
        private readonly ProjectContext db;
        public UnitOfWork(ProjectContext db)
        {
            this.db = db;
        }


        private TableRepository tableRepository;
        private BookingRepository bookingRepository;
        private GuestRepository guestRepository;
        public TableRepository TableRepository
        {
            get
            {

                if (this.tableRepository == null)
                {
                    this.tableRepository = new TableRepository(db);
                }
                return tableRepository;
            }
        }
        public BookingRepository BookingRepository
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
        public GuestRepository GuestRepository
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
