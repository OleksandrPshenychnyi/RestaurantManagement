using RestaurantManagement.BLL.DTO;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.BLL
{
    public class BookingDTO
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
        public User User { get; set; }
        public int? GuestId { get; set; }
        public GuestDTO Guest { get; set; }
        public int TableId { get; set; }
        public TableDTO Table { get; set; }
        public List<Booking_MealDTO> Booking_Meals { get; set; }
    }
}
