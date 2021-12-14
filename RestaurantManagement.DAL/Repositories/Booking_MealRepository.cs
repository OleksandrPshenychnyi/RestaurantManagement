using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Repositories
{
    public class Booking_MealRepository : IBookings_MealsRepository
    {
        private ProjectContext db;
        public Booking_MealRepository(ProjectContext context)
        {
            db = context;

        }
        public async Task CreateAsync(int bookingId, IEnumerable<int> mealId, IEnumerable<int> amount)
        {
            var massBooking = new List<Booking_Meal>();
            var mealsAndAmount = mealId.Zip(amount, (m, a) => new { MealId = m, Amount = a });
            foreach (var ma in mealsAndAmount)
            {
                Booking_Meal booking_meal = new Booking_Meal()
                {
                    BookingId = bookingId,
                    MealId = ma.MealId,
                    MealReady = false,
                    Amount = ma.Amount
                };
                massBooking.Add(booking_meal);
            }

            await db.Booking_Meals.AddRangeAsync(massBooking);
            await db.SaveChangesAsync();
        }
        public async Task UpdateAsync(int bookingId, IEnumerable<int> mealId)
        {

            IEnumerable<Booking_Meal> booking_meal = db.Booking_Meals.Where(b => b.BookingId == bookingId && b.MealReady == false && mealId.Contains(b.MealId)).ToList();

            foreach (var item in booking_meal)
            {
                item.MealReady = true;
            }

            db.Booking_Meals.UpdateRange(booking_meal);
            await db.SaveChangesAsync();
        }
    }
}
