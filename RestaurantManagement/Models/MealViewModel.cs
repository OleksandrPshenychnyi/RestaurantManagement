using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class MealViewModel
    {
        public int MealId { get; set; }

        public string MealName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }

        public double? UnitPrice { get; set; }

        public int? CategoryID { get; set; }
        public List<Booking_Meal> Booking_Meals { get; set; }
        public virtual Category Category { get; set; }
    }
}
