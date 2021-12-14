using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManagement.BLL.DTO
{
    public class UserDTO : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        public ICollection<BookingDTO> Bookings { get; set; }
    }
}
