using Microsoft.AspNetCore.Http;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.DTO
{
    public class MealDTO
    {
        public int MealId { get; set; }
        [Required]
        public string MealName { get; set; }
        [Required]
        public string Description { get; set; }
       
        public string ImagePath { get; set; }
        [Required]
        public string Category { get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }

        public List<Booking_Meal> Booking_Meals { get; set; }
       
    }
}
