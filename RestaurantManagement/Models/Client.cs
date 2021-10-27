using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Client
    {

        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int PhoneNumber { get; set; }
        public int TableNumber { get; set; }
        public List<Booking> Bookings { get; set; }
        //public Client(){
        //    Bookings = new List<Booking>();
        //    }
        public int TableId { get; set; }
    }
}
