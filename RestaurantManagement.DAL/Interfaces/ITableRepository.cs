
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
   public interface ITableRepository : IDisposable
    {
         IEnumerable<Table> GetTables();
        Task<Table> GetAsync(int? id);
        void CreateAsync(Table table);
        void UpdateAsync(Table table);
        void DeleteAsync(int id);
        void SaveAsync();
    }
}
