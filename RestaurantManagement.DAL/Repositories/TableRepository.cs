using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL
{
    public class TableRepository : IDisposable, IGenericRepository<Table>
    {
        private readonly ProjectContext db;

        public TableRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<Table> GetAll()
        {
           
           return db.Tables.ToList();
        }

        public Table Get(int id)
        {

            return db.Tables.Find(id);
        }

        public void Create(Table table)
        {
           db.Tables.Add(table);
            
        }

        public void Update(Table table)
        {
            db.Entry(table).State = EntityState.Modified;
            

        }

        public void Delete(int id)
        {
             Table table =  db.Tables.Find(id);
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
