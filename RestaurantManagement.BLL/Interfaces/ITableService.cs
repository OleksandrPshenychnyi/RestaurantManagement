using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
    public interface ITableService
    {
        
        // TableDTO GetTable(int? id);
        Task<IEnumerable<TableDTO>> GetTablesAsync();
        void Dispose();
    }
}
