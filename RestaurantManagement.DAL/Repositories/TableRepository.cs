using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class TableRepository : IDisposable, ITableRepository
    {
        private readonly ProjectContext db;

        public TableRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Table> GetTables()
        {
           
           return db.Tables.ToList();
        }

        public async Task<Table> GetAsync(int? id)
        {
            //var tableFind = db.Tables.Find(id);

            return await db.Tables.FindAsync(id);
        }

        public async void CreateAsync(Table table)
        {
          await db.Tables.AddAsync(table);
        }

        public async void UpdateAsync(Table table)
        {
            db.Entry(table).State = EntityState.Modified;
           
        }

        public async void DeleteAsync(int id)
        {
             Table table = await db.Tables.FindAsync(id);
            if (table != null)
                db.Tables.Remove(table);
        }

            public async void SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
