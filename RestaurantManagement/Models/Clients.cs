using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class Clients
    {
        
        public int ClientsId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public int PhoneNumber { get; set; }
        public int TableNumber { get; set; }
        
        public int TableId { get; set; }
    }
}
