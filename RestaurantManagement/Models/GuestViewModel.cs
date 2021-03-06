using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class GuestViewModel
    {

        public int GuestId { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter your surname")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = "Enter your phone number")]
        public int PhoneNumber { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        public BookingViewModel Booking { get; set; }
        public bool Served { get; set; }
        public int TableId { get; set; }
        
    }
}
