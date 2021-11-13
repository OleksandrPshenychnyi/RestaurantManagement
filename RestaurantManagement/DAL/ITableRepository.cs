using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    interface ITableRepository<T> where T : class
    {
         IEnumerable<T> GetTables();
        T Get(int? id);
        void CreateAsync(T item);
        void Update(T item);
        void DeleteAsync(int id);
        void Save();
    }
}
