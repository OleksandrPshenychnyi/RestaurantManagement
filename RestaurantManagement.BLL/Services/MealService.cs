using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RestaurantManagement.BLL.Services
{
    public class MealService : IMealService
    {
        
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public MealService(ProjectContext context)
        {
            db = context;
            unitOfWork = new UnitOfWork(db);

        }
        public async Task<IEnumerable<Meal>> GetMealsAsync()
        {

            var mealGet = await unitOfWork.Meals.GetAllMealsAsync();

            return mealGet;
        }
        public async Task<Meal> GetOneMealAsync(int? id)
        {

            var mealGet = await unitOfWork.Meals.GetOneMealAsync(id);

            return mealGet;
        }
        public async Task CreateMealAsync(Meal meal)
        {
            
            await unitOfWork.Meals.CreateMealAsync(meal);
        }
        public async Task UpdateMealAsync(Meal meal)
        {
            await unitOfWork.Meals.UpdateAsync(meal);
        }
        public async Task DeleteMealAsync(int id)
        {
            await unitOfWork.Meals.DeleteAsync(id);
        }
        public async Task<bool> MealExists(int id)
        {
            return await unitOfWork.Meals.Exists(id);
        }
      
        public async Task<IEnumerable<Booking>> GetBookingForMeals (int? id)
        {
            var bookingMealGet = await unitOfWork.Bookings.GetBookingForMealAsync(id);
            return bookingMealGet;
        }
        public async Task CreateMealAsync( int bookingId, IEnumerable<int> mealId, IEnumerable<int> amount)
        {

            await unitOfWork.Bookings_Meals.CreateAsync(bookingId, mealId, amount);
        }
        public async Task UpdateStatusMealAsync(int id, IEnumerable<int> mealId)
        {
            
            await unitOfWork.Bookings_Meals.UpdateAsync(id, mealId);
        }
    }
}
