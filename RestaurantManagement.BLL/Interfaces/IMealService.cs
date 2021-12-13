using RestaurantManagement.BLL.DTO;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
    public interface IMealService
    {
        Task<IEnumerable<MealDTO>> GetMealsAsync();
        Task<MealDTO> GetOneMealAsync(int? id);
        Task CreateMealAsync(MealDTO meal);
        Task UpdateMealAsync(MealDTO meal);
        Task DeleteMealAsync(int id);
        Task<IEnumerable<BookingDTO>> GetBookingForMeals(int? id);
        Task CreateMealAsync(int bookingId, IEnumerable<int> mealId, IEnumerable<int> amount);
        Task UpdateStatusMealAsync(int id, IEnumerable<int> mealId);
        Task<bool> MealExists(int id);
    }
}
