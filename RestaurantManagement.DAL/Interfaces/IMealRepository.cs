using RestaurantManagement.DAL.Enteties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface IMealRepository : IGenericRepository<Meal>
    {
        Task<IEnumerable<Meal>> GetAllMealsAsync();
        Task<Meal> GetOneMealAsync(int? id);
        Task CreateMealAsync(Meal meal);
        Task<bool> Exists(int id);
        Task UpdateMealAsync(Meal meal);
        Task DeleteMealAsync(int id);
        Task<IEnumerable<Meal>> GetAllMealsFilteredAsync(IEnumerable<int> mealId);


    }
}
