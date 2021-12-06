
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Enteties
{
    public class Booking
    {
        public int Id { get; set; }
        public int? Discount { get; set; }
        public bool IsLogged { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
        public int? GuestId { get; set; }
        public Guest Guest { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public List<Booking_Meal> Booking_Meals { get; set; }
    }
}
