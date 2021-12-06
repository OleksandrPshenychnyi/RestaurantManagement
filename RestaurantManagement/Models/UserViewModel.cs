using Microsoft.AspNetCore.Identity;
using RestaurantManagement.DAL.Enteties;
using System.Collections.Generic;

namespace RestaurantManagement.Models
{
    public class UserViewModel : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public ICollection<BookingViewModel> Bookings { get; set; }
    }
}