using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
   public interface IGuestRepository : IDisposable
    {
        Task<IEnumerable<Guest>> GetGuestsAsync();
        Task<Guest> GetAsync(int id);
        void CreateAsync(Guest guest);
        void UpdateAsync(Guest guest);
        void DeleteAsync(int id);
        void SaveAsync();
    }
}
