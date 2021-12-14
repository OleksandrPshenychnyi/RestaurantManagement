
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.DAL.Enteties
{
    public class Booking
    {
        public int Id { get; set; }
        public int? Discount { get; set; }
        public bool IsLogged { get; set; }
        public string Status { get; set; }
        public decimal Bill { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CloseReservationDate { get; set; }
        public User User { get; set; }
        public int? GuestId { get; set; }
        public Guest Guest { get; set; }
        public int TableId { get; set; }
        public Table Table { get; set; }
        public List<Booking_Meal> Booking_Meals { get; set; }
    }
}
