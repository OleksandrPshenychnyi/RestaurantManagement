using RestaurantManagement.DAL.Enteties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllUserBookingAsync();
        Task<IEnumerable<Booking>> GetAllGuestBookingAsync();
        Task<IEnumerable<Booking>> GetGuestBookingAsync(int? id);
#nullable enable
        Task<IEnumerable<Booking>> GetUserBookingAsync(string? id);
        Task<IEnumerable<Booking>> GetBookingForMealAsync(int? id);

        new Task CreateAsync(Booking booking);
        new Task UpdateAsync(Booking booking);
        new Task DeleteAsync(int id);
        new Task SaveAsync();
    }
}
