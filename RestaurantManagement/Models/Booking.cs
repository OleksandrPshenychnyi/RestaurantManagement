using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int? Discount { get; set; }
        public string Dish { get; set; }
        public bool IsLogged { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public int? GuestId { get; set; }
        public Guest Guest { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
    }
}
