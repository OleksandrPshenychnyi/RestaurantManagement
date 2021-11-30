using AutoMapper;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Services
{
    public class TableService : IDisposable, ITableService
    {
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public TableService(ProjectContext context)
        {
            db = context;
            this.unitOfWork = new UnitOfWork(db);
            
        }
        public async Task<IEnumerable<TableDTO>> GetTablesAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Table, TableDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Table>, List<TableDTO>>(await unitOfWork.Tables.GetAll());
            
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
