using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.DAL.Enteties;
namespace RestaurantManagement.BLL
{
    public class TableDTO
    {
        public int TableId { get; set; }
        public int? WaiterId { get; set; }
        public bool IsAvailable { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string HallPlacing { get; set; }
        public List<Booking> Bookings { get; set; }
        public TableDTO()
        {
            Bookings = new List<Booking>();
        }
    }
}
