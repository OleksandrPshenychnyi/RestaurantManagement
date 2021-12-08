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
        Task<IEnumerable<Meal>> GetMealsAsync();
        Task<Meal> GetOneMealAsync(int? id);
        Task CreateMealAsync(Meal meal);
        Task UpdateMealAsync(Meal meal);
        Task DeleteMealAsync(int id);
        Task<IEnumerable<Booking>> GetBookingForMeals(int? id);
        Task CreateMealAsync(int bookingId, IEnumerable<int> mealId, IEnumerable<int> amount);
        Task UpdateStatusMealAsync(int id, IEnumerable<int> mealId);
        Task<bool> MealExists(int id);
    }
}
