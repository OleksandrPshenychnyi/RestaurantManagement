using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IEnumerable<TableDTO>> GetTablesListAsync()
        {
            var table = await unitOfWork.Tables.GetAll();
            var mappedTable = _mapper.Map<List<TableDTO>>(table);
            return mappedTable;

        }
        public async Task<IEnumerable<TableDTO>> GetTablesAsync()
        {
            var table = await unitOfWork.Tables.GetAll();
            var tableFiltered = table.Where(table => table.IsAvailable).ToList();
            var mappedTable = _mapper.Map<List<TableDTO>>(tableFiltered);
            return mappedTable;

        }
        public async Task<List<TableDTO>> GetOneTableAsync(int? id)
        {
            var table = await unitOfWork.Tables.GetOneTableAsync(id);
            var mappedTable = _mapper.Map<List<TableDTO>>(table);
            return mappedTable;

        }
        public async Task<TableDTO> GetTableAsync(int? id)
        {
            var table = await unitOfWork.Tables.GetTableAsync(id);
            
            var mappedTable = _mapper.Map<TableDTO>(table);
            return mappedTable;

        }
        public async Task CreateTableAsync(TableDTO table)
        {
            var mappedTableGet = _mapper.Map<Table>(table);
            await unitOfWork.Tables.CreateTableAsync(mappedTableGet);
        }
        public async Task UpdateTableAsync(TableDTO table)
        {
            var mappedTableGet = _mapper.Map<Table>(table);
            await unitOfWork.Tables.UpdateAsync(mappedTableGet);
        }
        public async Task DeleteTableAsync(int id)
        {
            await unitOfWork.Tables.DeleteAsync(id);
        }
        public async Task<bool> TableExists(int id)
        {
            return await unitOfWork.Tables.Exists(id);
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
