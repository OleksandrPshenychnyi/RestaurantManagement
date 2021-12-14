using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private ProjectContext db;
        private DbSet<TEntity> _dbSet;
        public GenericRepository(ProjectContext context)
        {
            db = context;
            _dbSet = db.Set<TEntity>();
        }
        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {

            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {

            return await _dbSet.FindAsync(id);
        }

        public virtual async Task CreateAsync(TEntity tEntity)
        {
            await _dbSet.AddAsync(tEntity);
            await db.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity tEntity)
        {
            db.Entry(tEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            TEntity tEntity = await _dbSet.FindAsync(id);
            if (tEntity != null)
                _dbSet.Remove(tEntity);
            await db.SaveChangesAsync();
        }

        public virtual async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
