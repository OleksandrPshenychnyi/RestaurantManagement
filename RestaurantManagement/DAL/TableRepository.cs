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
        private ClientContext db;

        public TableRepository(ClientContext context)
        {
            this.db = context;
        }

        public IEnumerable<Table> GetTables()
        {
           
            return db.Tables.Where(table => table.IsAvailable).ToList();
        }

        public Table Get(int id)
        {
            var tableFind = db.Tables.Find(id);

            return db.Tables.Find(id);
        }

        public void Create(Table table)
        {
            db.Tables.Add(table);
        }

        public void Update(Table table)
        {
            db.Entry(table).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Table table = db.Tables.Find(id);
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
