using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Courses
    {
        public int CoursesId { get; set; }
        public string MealName { get; set; }
        public string BriefDesc { get; set; }
        public int CookingTime { get; set; }
    }
}
