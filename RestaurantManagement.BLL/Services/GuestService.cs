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
        private readonly IMapper _mapper;
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public GuestService(ProjectContext context, IMapper mapper)
        {
            
            db = context;
            unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<GuestDTO>> GetAllGuestsAsync()
        {
            var guestGet = await unitOfWork.Guests.GetAll();
            var mappedGuestGet = _mapper.Map<List<GuestDTO>>(guestGet);
            return mappedGuestGet;
        }
    }
}
