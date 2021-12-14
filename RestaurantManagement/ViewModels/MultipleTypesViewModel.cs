
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using System.Collections.Generic;

namespace RestaurantManagement.ViewModels
{
    public class MultipleTypesViewModel
    {
        public IEnumerable<MealViewModel> Meals { get; set; }
        public IEnumerable<Booking_Meal> Booking_Meals { get; set; }
    }
}
