using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Enteties
{
    public class Guest
    {

        public int GuestId { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your surname")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Enter your phone number")]
        public int PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        public Booking Booking { get; set; }
        public bool Served { get; set; }
        public int TableId { get; set; }
        
    }
}
