
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
        
        Task CloseReservation(Guest guest, int tableId);
        Task ToBookAsync(GuestDTO guest, int id);
        Task ToBookAutorizedAsync(int tableId, User userGet);
      // Task GetTableAsync(int? id, string userId);
        IEnumerable<Booking> GetAllBookings();
        void Dispose();
    }
}
