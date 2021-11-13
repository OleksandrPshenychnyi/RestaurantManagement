using Microsoft.EntityFrameworkCore;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class TableRepository : IDisposable, ITableRepository<Table>
    {
        private readonly ClientContext db;

        public TableRepository(ClientContext context)
        {
            this.db = context;
        }

        public  IEnumerable<Table> GetTables()
        {
           
           return db.Tables.ToList();
        }

        public Table Get(int? id)
        {
            //var tableFind = db.Tables.Find(id);

            return db.Tables.Find(id);
        }

        public async void CreateAsync(Table table)
        {
           await db.Tables.AddAsync(table);
        }

        public  void Update(Table table)
        {
            db.Entry(table).State = EntityState.Modified;
           
        }

        public async void DeleteAsync(int id)
        {
            Table table =await db.Tables.FindAsync(id);
            if (table != null)
                db.Tables.Remove(table);
        }

            public void Save()
        {
            db.SaveChanges();
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
