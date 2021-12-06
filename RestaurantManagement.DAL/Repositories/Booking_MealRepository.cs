using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public async Task CreateAsync (int bookingId, IEnumerable<int> mealId)
        {
            var massBooking = new List<Booking_Meal>();
           
            foreach (var id in mealId)
            {

                Booking_Meal booking_meal = new Booking_Meal()
                {
                    BookingId = bookingId,
                    MealId = id,
                    MealReady = false
                };
                massBooking.Add(booking_meal);
            }
            
            await db.Booking_Meals.AddRangeAsync(massBooking);
            await db.SaveChangesAsync();
        }
        public async Task UpdateAsync(bool mealReady, IEnumerable<int> mealId)
        {
            var massBooking = new List<Booking_Meal>();

            foreach (var id in mealId)
            {

                Booking_Meal booking_meal = new Booking_Meal()
                {
                   
                    MealId = id,
                    MealReady = true
                };
                massBooking.Add(booking_meal);
            }

            await db.Booking_Meals.AddRangeAsync(massBooking);
            await db.SaveChangesAsync();
        }
    }
}
