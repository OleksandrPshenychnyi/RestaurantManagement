using RestaurantManagement.DAL.Enteties;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace RestaurantManagement.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<Booking>> GetOneBookingForUser(string id);


    }
}
