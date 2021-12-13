using RestaurantManagement.BLL.DTO;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        public User User { get; set; }
        public int? GuestId { get; set; }
        public GuestDTO Guest { get; set; }
        public int TableId { get; set; }
        public TableDTO Table { get; set; }
        public List<Booking_MealDTO> Booking_Meals { get; set; }
    }
}
