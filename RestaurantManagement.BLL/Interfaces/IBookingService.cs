using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace RestaurantManagement.BLL.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<BookingDTO>> GetBookingsAsync(string status,  bool isNull);
        Task<IEnumerable<BookingDTO>> GetMealsForArchiveAsync(int? guestId);
        Task<IEnumerable<BookingDTO>> GetOneBookingGuestAsync(int? id);
#nullable enable
        Task<IEnumerable<BookingDTO>> GetOneBookingUserAsync(string? id);
        Task ToBookAsync(GuestDTO guest, int id, IEnumerable<int> mealId, IEnumerable<int> amount);
        Task ToBookAutorizedAsync(int tableId, User userGet, IEnumerable<int> mealId, IEnumerable<int> amount, decimal tableDiscount, DateTime dateTime);
        Task CloseReservationGuest(int guestId, int tableId);
        Task CloseReservationUser(string userId, int tableId);
        void Dispose();
    }
}
