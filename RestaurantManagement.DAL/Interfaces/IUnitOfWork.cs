using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IBookingRepository Bookings { get; }
        IGuestRepository Guests { get; }
        IMealRepository Meals { get; }
        IBookings_MealsRepository Bookings_Meals { get; }
        ITableRepository Tables { get; }
        IGenericRepository<User> Users { get; }
    }
}
