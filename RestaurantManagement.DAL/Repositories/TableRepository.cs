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
    public class TableRepository : GenericRepository<Table>, ITableRepository
    {
        private ProjectContext db;

        public TableRepository(ProjectContext context) : base(context)
        {
            db = context;

        }
        public async Task<IEnumerable<Table>> GetOneTableAsync(int? id)
        {
            var getTables = await db.Tables.Where(t => t.TableId == id).ToListAsync();
            return getTables;
        }
        public async Task<IEnumerable<Table>> GetAllTablesAsync()
        {

            return await db.Tables.ToListAsync();
        }

        public async Task CreateTableAsync(Table table)
        {
            await db.AddAsync(table);
            await db.SaveChangesAsync();
        }
        public override async Task UpdateAsync(Table table)
        {
            db.Entry(table).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public override async Task DeleteAsync(int id)
        {
            var table = await db.Meals.FindAsync(id);
            if (table != null)
                db.Remove(table);
            await db.SaveChangesAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await db.Tables.AnyAsync(e => e.TableId == id);
        }
        public async Task<Table> GetTableAsync(int? id)
        {

            return await db.Tables.FindAsync(id); ;
        }
    }
}
