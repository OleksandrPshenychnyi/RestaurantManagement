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
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
