using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.DTO
{
   public class Booking_MealDTO
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int MealId { get; set; }
        public int Amount { get; set; } = 1;

        public bool MealReady { get; set; }
        public MealDTO Meal { get; set; }
        public BookingDTO Booking { get; set; }
    }
}
