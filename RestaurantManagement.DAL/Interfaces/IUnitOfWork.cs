namespace RestaurantManagement.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IBookingRepository Bookings { get; }
        IGuestRepository Guests { get; }
        IMealRepository Meals { get; }
        IBookings_MealsRepository Bookings_Meals { get; }
        ITableRepository Tables { get; }
        IUserRepository Users { get; }
    }
}
