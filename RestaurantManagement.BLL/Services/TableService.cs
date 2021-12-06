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
        private readonly IMapper _mapper;
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public TableService(ProjectContext context, IMapper mapper)
        {
            db = context;
            this.unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }
        public async Task<IEnumerable<TableDTO>> GetTablesAsync()
        {
            var table = await unitOfWork.Tables.GetAll();
            var tableFiltered = table.Where(table => table.IsAvailable).ToList();
            var mappedTable = _mapper.Map<List<TableDTO>>(tableFiltered);
            return mappedTable;

        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
