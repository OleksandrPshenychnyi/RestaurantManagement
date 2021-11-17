using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Enteties
{
    public class Guest
    {

        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int PhoneNumber { get; set; }
        public Booking Booking { get; set; }
        //public Client(){
        //    Bookings = new List<Booking>();
        //    }
        public int TableId { get; set; }
    }
}
