namespace RestaurantManagement.DAL.Enteties
{
    public class Booking_Meal
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public int MealId { get; set; }
        public int Amount { get; set; } = 1;
        public bool MealReady { get; set; }
        public Meal Meal { get; set; }
        public Booking Booking { get; set; }
    }
}
