using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface IBookings_MealsRepository
    {
        Task CreateAsync(int bookingId, IEnumerable<int> mealId, IEnumerable<int> amount);
        Task UpdateAsync(int bookingId, IEnumerable<int> mealId);
        
    }
}
