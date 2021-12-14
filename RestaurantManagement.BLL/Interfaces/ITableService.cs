using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
    public interface ITableService
    {

        Task<IEnumerable<TableDTO>> GetTablesListAsync();
        Task<IEnumerable<TableDTO>> GetTablesAsync();
        Task<List<TableDTO>> GetOneTableAsync(int? id);
        Task CreateTableAsync(TableDTO table);
        Task UpdateTableAsync(TableDTO table);
        Task DeleteTableAsync(int id);
        Task<TableDTO> GetTableAsync(int? id);
        Task<bool> TableExists(int id);
        void Dispose();
    }
}
