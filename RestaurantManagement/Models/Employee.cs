using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int Identifier { get; set; }
        public decimal Salary { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
