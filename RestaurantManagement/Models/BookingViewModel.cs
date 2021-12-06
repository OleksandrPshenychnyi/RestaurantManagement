using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public int? Discount { get; set; }
        public string Dish { get; set; }
        public bool IsLogged { get; set; }
        public string Status { get; set; }
        public UserViewModel User { get; set; }
        public int? GuestId { get; set; }
        public GuestViewModel Guest { get; set; }
        public int TableId { get; set; }
        public TableViewModel Table { get; set; }
    }
}
