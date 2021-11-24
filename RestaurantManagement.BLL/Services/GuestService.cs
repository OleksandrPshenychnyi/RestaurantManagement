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
    public class GuestService : IGuestService
    {
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public GuestService(ProjectContext context)
        {
            
            db = context;
            unitOfWork = new UnitOfWork(db);

        }
        public async Task<Guest> GetGuestAsync(int id)
        {
           var guest= await unitOfWork.Guests.GetAsync(id);
            return guest;
        }
        public IEnumerable<Guest> GetAllGuestsAsync()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Guest, GuestDTO>()).CreateMapper();
            return unitOfWork.Guests.GetAll();
        }
    }
}
