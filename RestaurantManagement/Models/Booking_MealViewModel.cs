namespace RestaurantManagement.Models
{
    public class Booking_MealViewModel
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int MealId { get; set; }
        public int Amount { get; set; } = 1;
        public bool MealReady { get; set; }
        public MealViewModel Meal { get; set; }
        public BookingViewModel Booking { get; set; }
    }
}
