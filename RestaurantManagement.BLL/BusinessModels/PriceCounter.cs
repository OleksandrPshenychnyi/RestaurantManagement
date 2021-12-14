using RestaurantManagement.DAL.Enteties;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantManagement.BLL.BusinessModels
{
    public class PriceCounter
    {
        public decimal MealPriceAsync(IEnumerable<Meal> mealId, IEnumerable<int> amount)
        {
            var mealsAndAmount = mealId.Zip(amount, (m, a) => new { MealId = m, Amount = a });
            decimal count = 0;
            decimal sum = 0;
            foreach (var ma in mealsAndAmount)
            {
                var price = ma.MealId.UnitPrice;
                var amountCount = ma.Amount;
                count = price * amountCount;
                sum += count;
            }
            return sum;

        }
    }
}
