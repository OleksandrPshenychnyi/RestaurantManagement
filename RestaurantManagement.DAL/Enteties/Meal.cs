using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Enteties
{
    public class Meal
    {
        
        public int MealId { get; set; }

        public string MealName { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }

        public double? UnitPrice { get; set; }

        public int? CategoryID { get; set; }
        public List<Booking_Meal> Booking_Meals { get; set; }
        public virtual Category Category { get; set; }
    }
}
