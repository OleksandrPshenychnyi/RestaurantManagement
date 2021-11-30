using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
   public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllUserBookingAsync();
        Task<IEnumerable<Booking>> GetAllGuestBookingAsync();
        new Task<IEnumerable<Booking>> GetGuestBookingAsync(int id);
        new Task<IEnumerable<Booking>> GetUserBookingAsync(string id);
        new Task CreateAsync(Booking booking);
        new Task UpdateAsync(Booking booking);
        new Task DeleteAsync(int id);
        new Task SaveAsync();
    }
}
