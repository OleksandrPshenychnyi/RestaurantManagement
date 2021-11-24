using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class GuestViewModel
    {

        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int PhoneNumber { get; set; }
        public BookingViewModel Booking { get; set; }
        //public Client(){
        //    Bookings = new List<Booking>();
        //    }
        public bool Served { get; set; }
        public int TableId { get; set; }
        
    }
}
