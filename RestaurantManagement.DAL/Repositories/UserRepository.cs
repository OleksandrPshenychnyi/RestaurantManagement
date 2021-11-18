using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Repositories
{
    public class UserRepository : IGenericRepository<User>
    {
        private ProjectContext db;
        
        public UserRepository(ProjectContext context)
        {
            this.db = context;
        }

        public IEnumerable<User> GetAll()
        {

            return  db.Users.ToList();
        }

        public User Get(int id)
        {

            return  db.Users.Find(id);
        }

        public  void Create(User user)
        {
             db.Users.Add(user);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            User user =  db.Users.Find(id);
            if (user != null)
                db.Users.Remove(user);
        }

        public  void Save()
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
