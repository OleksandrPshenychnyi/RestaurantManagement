using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface IGuestRepository : IGenericRepository<Guest>
    {
          Task<IEnumerable<Guest>> GetAsync(int id);
    }
}
