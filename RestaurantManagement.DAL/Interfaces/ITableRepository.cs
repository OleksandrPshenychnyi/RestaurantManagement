using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface ITableRepository : IGenericRepository<Table>
    {
        Task<IEnumerable<Table>> GetOneTableAsync(int? id);
        Task<IEnumerable<Table>> GetAllTablesAsync();
        Task CreateTableAsync(Table meal);
        Task<Table> GetTableAsync(int? id);
        Task<bool> Exists(int id);
    }
}
