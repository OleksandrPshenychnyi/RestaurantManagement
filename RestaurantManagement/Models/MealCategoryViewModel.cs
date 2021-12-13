using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantManagement.BLL.DTO;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class MealCategoryViewModel
    {
#nullable enable
        public List<MealDTO>? Meals { get; set; }
        public SelectList? Categories { get; set; }
        public string? MealCategory { get; set; }
        public string? SearchString { get; set; }
    }
}
