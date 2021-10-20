using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public string HallPlacing { get; set; }
        
        public bool IsAvailable { get; set; }
        // public DateTime DateTime { get; set; }
        public int ClientId { get; set; }
        public Clients Clients { get; set; }
    }
}
