using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int TableId{ get; set; }
        
        
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public Table Table { get; set; }
    }
}
