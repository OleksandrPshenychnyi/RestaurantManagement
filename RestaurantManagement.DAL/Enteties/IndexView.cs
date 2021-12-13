using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Enteties
{
   public class IndexView
    {
        public IEnumerable<Meal> Meals { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
