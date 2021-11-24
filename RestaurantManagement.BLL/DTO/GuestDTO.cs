using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagement.DAL.Enteties;
namespace RestaurantManagement.BLL
{
    public class GuestDTO
    {

        public int GuestId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int PhoneNumber { get; set; }
        public Booking Booking { get; set; }
        //public Client(){
        //    Bookings = new List<Booking>();
        //    }
        public bool Served { get; set; }
        public int TableId { get; set; }
        
    }
}
