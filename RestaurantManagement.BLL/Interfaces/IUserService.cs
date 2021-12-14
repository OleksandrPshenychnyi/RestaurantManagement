using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<BookingDTO>> GetOneUserBookings(string id);
    }
}
