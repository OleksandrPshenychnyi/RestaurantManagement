
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.ViewModels
{
    public class MultipleTypesViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Table> Tables { get; set; }
    }
}
