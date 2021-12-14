using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantManagement.BLL.DTO;
using System.Collections.Generic;

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
