using System.Collections.Generic;

namespace RestaurantManagement.Models
{
    public class TableViewModel
    {
        public int TableId { get; set; }
        public bool IsAvailable { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string HallPlacing { get; set; }
        public int TablePrice { get; set; }
        public decimal TableDiscount { get; set; }
        public List<BookingViewModel> Bookings { get; set; }
        public TableViewModel()
        {
            Bookings = new List<BookingViewModel>();
        }
    }
}
