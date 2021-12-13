using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
   public interface IGuestService
    {
        //Task<Guest> GetGuestAsync(int id);
        Task<IEnumerable<GuestDTO>> GetAllGuestsAsync();
    }
}
