
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.ViewModels
{
    public class MultipleTypesViewModel
    {
        public IEnumerable<MealViewModel> Meals { get; set; }
        public IEnumerable<Booking_Meal> Booking_Meals { get; set; }
    }
}
