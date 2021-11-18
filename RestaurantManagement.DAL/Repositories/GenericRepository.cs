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

            return _dbSet.ToList();
        }

        public TEntity Get(int id)
        {

            return _dbSet.Find(id);
        }

        public void Create(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
            
        }

        public void Update(TEntity tEntity)
        {
            db.Entry(tEntity).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            TEntity tEntity = _dbSet.Find(id);
            if (tEntity != null)
                _dbSet.Remove(tEntity);

        }

        public void Save()
        {
            db.SaveChanges();
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
