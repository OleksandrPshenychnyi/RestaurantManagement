using RestaurantManagement.DAL.Enteties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface IGuestRepository : IGenericRepository<Guest>
    {
        Task<IEnumerable<Guest>> GetGuestAsync(int id);
    }
}
