using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string MealName { get; set; }
        public string BriefDesc { get; set; }
        public int CookingTime { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
