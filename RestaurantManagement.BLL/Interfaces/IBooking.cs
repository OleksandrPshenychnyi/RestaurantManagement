
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Interfaces
{
    public interface IBooking
    {
        void ToBookAsync(GuestDTO guest, int id);
       // TableDTO GetTable(int? id);
        //IEnumerable<TableDTO> GetTables();
        void Dispose();
    }
}
