using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.Models
{
    public class BookingViewModel
    {
        public int Id { get; set; }
        public int? Discount { get; set; }
        public string Dish { get; set; }
        public bool IsLogged { get; set; }
        public string Status { get; set; }
        public decimal Bill { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime CloseReservationDate { get; set; }
        public UserViewModel User { get; set; }
        public int? GuestId { get; set; }
        public GuestViewModel Guest { get; set; }
        public int TableId { get; set; }
        public TableViewModel Table { get; set; }
        public List<Booking_MealViewModel> Booking_Meals { get; set; }
    }
}
