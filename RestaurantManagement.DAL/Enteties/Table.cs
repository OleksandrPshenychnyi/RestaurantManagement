using System.Collections.Generic;

namespace RestaurantManagement.DAL.Enteties
{
    public class Table
    {
        public int TableId { get; set; }
        public bool IsAvailable { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string HallPlacing { get; set; }
        public decimal TablePrice { get; set; }
        public decimal TableDiscount { get; set; }
        public List<Booking> Bookings { get; set; }
        public Table()
        {
            Bookings = new List<Booking>();
        }
    }
}
