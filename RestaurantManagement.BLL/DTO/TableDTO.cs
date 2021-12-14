using System.Collections.Generic;
namespace RestaurantManagement.BLL
{
    public class TableDTO
    {
        public int TableId { get; set; }
        public bool IsAvailable { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string HallPlacing { get; set; }
        public int TablePrice { get; set; }
        public decimal TableDiscount { get; set; }
        public List<BookingDTO> Bookings { get; set; }
        public TableDTO()
        {
            Bookings = new List<BookingDTO>();
        }
    }
}
