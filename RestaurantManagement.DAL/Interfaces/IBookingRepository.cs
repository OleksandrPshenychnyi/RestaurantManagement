using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
   public interface IBookingRepository: IDisposable
    {
        Task<IEnumerable<Booking>> GetBookingsAsync();
        Task<Booking> GetAsync(int id);
        void  CreateAsync(Booking booking);
        void UpdateAsync(Booking booking);
        void DeleteAsync(int id);
        void SaveAsync();
    }
}
