using AutoMapper;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public UserService(ProjectContext context, IMapper mapper)
        {
         
            db = context;
            unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }
        public async Task<IEnumerable<BookingDTO>> GetOneUserBookings(string id)
        {
            var allBookingsUser = await unitOfWork.Users.GetOneBookingForUser(id);
            var mappedallBookingsUser = _mapper.Map<List<BookingDTO>>(allBookingsUser);
            return mappedallBookingsUser;
        }
    }
}
