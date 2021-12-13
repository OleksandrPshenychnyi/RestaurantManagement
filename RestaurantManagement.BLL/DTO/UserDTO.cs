using Microsoft.AspNetCore.Identity;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.DTO
{
    public class UserDTO : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReservationDate { get; set; }
        public ICollection<BookingDTO> Bookings { get; set; }
    }
}
