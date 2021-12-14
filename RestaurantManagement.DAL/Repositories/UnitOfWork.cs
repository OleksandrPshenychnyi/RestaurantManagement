
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Interfaces;
using RestaurantManagement.DAL.Repositories;
using System;

namespace RestaurantManagement.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectContext db;
        public UnitOfWork(ProjectContext db)
        {
            this.db = db;
        }


        private TableRepository tableRepository;
        private GuestRepository guestRepository;
        private UserRepository userRepository;
        private BookingRepository bookingRepository;
        private Booking_MealRepository booking_mealRepository;
        private MealRepository mealRepository;
        public ITableRepository Tables
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
        public IUserRepository Users
        {
            get
            {

                if (this.userRepository == null)
                {
                    this.userRepository = new UserRepository(db);
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
        public IBookings_MealsRepository Bookings_Meals
        {
            get
            {

                if (this.booking_mealRepository == null)
                {
                    this.booking_mealRepository = new Booking_MealRepository(db);
                }
                return booking_mealRepository;
            }
        }
        public IMealRepository Meals
        {
            get
            {

                if (this.mealRepository == null)
                {
                    this.mealRepository = new MealRepository(db);
                }
                return mealRepository;
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
        public void SaveAsync()
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
