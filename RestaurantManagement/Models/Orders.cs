using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Courses> Courses { get; set; }
    }
}
