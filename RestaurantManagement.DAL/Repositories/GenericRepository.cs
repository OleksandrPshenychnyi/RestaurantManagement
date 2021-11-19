using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Repositories
{
   public class GenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity:class
    {
       private ProjectContext db;
       private DbSet<TEntity> _dbSet;
        public GenericRepository(ProjectContext context)
        {
            db = context;
            _dbSet = db.Set<TEntity>();
        }
        public IEnumerable<TEntity> GetAll()
        {

            return  _dbSet.ToList();
        }

        public async Task< TEntity> GetAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public async Task CreateAsync(TEntity tEntity)
        {
           await _dbSet.AddAsync(tEntity);
            await db.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity tEntity)
        {
            db.Entry(tEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            TEntity tEntity =await _dbSet.FindAsync(id);
            if (tEntity != null)
                _dbSet.Remove(tEntity);
            await db.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
    }
}
