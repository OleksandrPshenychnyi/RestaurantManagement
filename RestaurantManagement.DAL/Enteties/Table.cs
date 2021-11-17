using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Enteties
{
    public class Table
    {
        public int TableId { get; set; }
        public int? WaiterId { get; set; }
        public bool IsAvailable { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string HallPlacing { get; set; }
        public List<Booking> Bookings { get; set; }
        public Table()
        {
            Bookings = new List<Booking>();
        }
    }
}
