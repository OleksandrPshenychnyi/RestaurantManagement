using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
    public interface IGuestService
    {
        Task<IEnumerable<GuestDTO>> GetAllGuestsAsync();
    }
}
