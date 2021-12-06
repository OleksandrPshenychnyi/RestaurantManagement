using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
   public interface IMealRepository : IGenericRepository<Meal>
    {
        Task<IEnumerable<Meal>> GetAllMealsAsync();
        Task<Meal> GetOneMealAsync(int? id);
        Task CreateMealAsync(Meal meal);
        Task<bool> Exists(int id);
       
    }
}
