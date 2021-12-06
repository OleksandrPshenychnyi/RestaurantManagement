
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace RestaurantManagement.BLL.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetBookingsAsync(string status,  bool isNull);
        Task<IEnumerable<Booking>> GetOneBookingGuestAsync(int? id);
#nullable enable
        Task<IEnumerable<Booking>> GetOneBookingUserAsync(string? id);
        Task ToBookAsync(GuestDTO guest, int id, IEnumerable<int> mealId);
        Task ToBookAutorizedAsync(int tableId, User userGet, IEnumerable<int> mealId);
        Task CloseReservationGuest(int guestId, int tableId);
        Task CloseReservationUser(string userId, int tableId);
        void Dispose();
    }
}
