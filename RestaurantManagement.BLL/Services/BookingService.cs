
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.BLL.Services
{
    public class BookingService : IDisposable,IBooking
    {
        private UnitOfWork unitOfWork;
        ProjectContext db;
        public BookingService(ProjectContext context)
        {
            db = context;
            this.unitOfWork = new UnitOfWork(db);

        }
        public async void ToBookAsync(GuestDTO guestDto, int tableId)
        {
            var guestObj = new Guest { TableId = guestDto.TableId,GuestId = guestDto.GuestId,FirstName = guestDto.FirstName,
                SecondName = guestDto.SecondName, PhoneNumber = guestDto.PhoneNumber };
            unitOfWork.GuestRepository.CreateAsync(guestObj);
            unitOfWork.SaveAsync();
            int guestid = guestObj.GuestId ;
            Booking booking = new Booking()
            {
                IsLogged = false,
                GuestId = guestid,
                TableId = tableId,
                Status = "Reserved"
            };
            unitOfWork.BookingRepository.CreateAsync(booking);
            unitOfWork.SaveAsync();
            // Error???
            // bookingRepository.Update(bookingObj);

            var table =await unitOfWork.TableRepository.GetAsync(tableId);
            table.IsAvailable = false;
            unitOfWork.TableRepository.UpdateAsync(table);
            unitOfWork.SaveAsync();
        }
        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
