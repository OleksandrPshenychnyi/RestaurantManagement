using AutoMapper;
using RestaurantManagement.BLL.BusinessModels;
using RestaurantManagement.BLL.DTO;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Services
{
    public class MealService : IMealService
    {
        private readonly IMapper _mapper;
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public MealService(ProjectContext context, IMapper mapper)
        {
            db = context;
            unitOfWork = new UnitOfWork(db);
            _mapper = mapper;
        }
        public async Task<IEnumerable<MealDTO>> GetMealsAsync()
        {

            var mealGet = await unitOfWork.Meals.GetAllMealsAsync();
            var mappedMealGet = _mapper.Map<List<MealDTO>>(mealGet);
            return mappedMealGet;
        }
        public async Task<MealDTO> GetOneMealAsync(int? id)
        {

            var mealGet = await unitOfWork.Meals.GetOneMealAsync(id);
            var mappedMealGet = _mapper.Map<MealDTO>(mealGet);
            return mappedMealGet;
        }
        public async Task CreateMealAsync(MealDTO meal)
        {
            var mappedMealGet = _mapper.Map<Meal>(meal);
            await unitOfWork.Meals.CreateMealAsync(mappedMealGet);
        }
        public async Task UpdateMealAsync(MealDTO meal)
        {
            var mappedMealGet = _mapper.Map<Meal>(meal);
            await unitOfWork.Meals.UpdateAsync(mappedMealGet);
        }
        public async Task DeleteMealAsync(int id)
        {
            await unitOfWork.Meals.DeleteAsync(id);
        }
        public async Task<bool> MealExists(int id)
        {
            return await unitOfWork.Meals.Exists(id);
        }

        public async Task<IEnumerable<BookingDTO>> GetBookingForMeals(int? id)
        {
            var bookingMealGet = await unitOfWork.Bookings.GetBookingForMealAsync(id);
            var mappedMealGet = _mapper.Map<List<BookingDTO>>(bookingMealGet);
            return mappedMealGet;
        }
        public async Task CreateMealAsync(int bookingId, IEnumerable<int> mealId, IEnumerable<int> amount)
        {

            await unitOfWork.Bookings_Meals.CreateAsync(bookingId, mealId, amount);
            var oneBooking = await unitOfWork.Bookings.GetAsync(bookingId);
            var massMeals = await unitOfWork.Meals.GetAllMealsFilteredAsync(mealId);
            decimal price = new PriceCounter().MealPriceAsync(massMeals, amount);
            oneBooking.Bill += price;
            await unitOfWork.Bookings.UpdateAsync(oneBooking);
        }
        public async Task UpdateStatusMealAsync(int id, IEnumerable<int> mealId)
        {

            await unitOfWork.Bookings_Meals.UpdateAsync(id, mealId);
        }
    }
}
