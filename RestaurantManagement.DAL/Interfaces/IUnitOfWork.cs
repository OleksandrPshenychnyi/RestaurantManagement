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
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Guest> Guests { get; }
        IGenericRepository<Table> Tables { get; }
        IGenericRepository<User> Users { get; }
    }
}
