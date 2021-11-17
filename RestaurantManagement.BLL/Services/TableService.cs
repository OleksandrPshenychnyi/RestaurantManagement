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
    public class TableService : IDisposable, ITable
    {
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public TableService(ProjectContext context)
        {
            db = context;
            this.unitOfWork = new UnitOfWork(db);
            
        }
        public IEnumerable<TableDTO> GetTablesAsync()
        {
            
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Table, TableDTO>()).CreateMapper();
            return  mapper.Map<IEnumerable<Table>, List<TableDTO>>(unitOfWork.TableRepository.GetTables());
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
