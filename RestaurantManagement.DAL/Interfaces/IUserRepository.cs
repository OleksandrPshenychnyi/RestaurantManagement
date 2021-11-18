using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantManagement.DAL.Enteties;
namespace RestaurantManagement.DAL.Interfaces
{
   public interface IUserRepository :IDisposable
    {
        Task<IEnumerable<User>> GetUserAsync();
        Task<User> GetAsync(int id);
        void CreateAsync(User user);
        void UpdateAsync(User user);
        void DeleteAsync(int id);
        void SaveAsync();
    }
}
