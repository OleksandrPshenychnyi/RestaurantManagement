using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Controllers
{
    [Authorize(Roles = "Waiter")]
    public class WaiterController : Controller
    {
        private readonly IMapper _mapper;
        IBookingService bookingService;
        IGuestService guestService;
        IMealService mealService;
        ProjectContext db;
        private readonly UserManager<User> _userManager;
        public WaiterController(ProjectContext context, IBookingService servB, IGuestService servG, IMealService servM, UserManager<User> UserManager, IMapper mapper)
        {
            mealService = servM;
            _userManager = UserManager;
            bookingService = servB;
            db = context;
            guestService = servG;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var bookingDtosUser = await bookingService.GetBookingsAsync("Reserved", false);
            var mappedBookingUserView = _mapper.Map<List<BookingViewModel>>(bookingDtosUser);
            ViewBag.User = mappedBookingUserView;

            var bookingDtosGuest = await bookingService.GetBookingsAsync("Reserved", true);
            var mappedBookingGuestView = _mapper.Map<List<BookingViewModel>>(bookingDtosGuest);
            ViewBag.Guest = mappedBookingGuestView;

            return await Task.Run(() => View());
        }
        public async Task<IActionResult> Archive()
        {

            var closedBookingsUser = await bookingService.GetBookingsAsync("Closed", false);
            var closedBookingUserView = _mapper.Map<List<BookingViewModel>>(closedBookingsUser);
            ViewBag.User = closedBookingUserView;
            var closedBookingsGuest = await bookingService.GetBookingsAsync("Closed", true);
            var closedBookingGuestView = _mapper.Map<List<BookingViewModel>>(closedBookingsGuest);
            ViewBag.Guest = closedBookingGuestView;


            return await Task.Run(() => View());
        }
        public async Task<IActionResult> ArchivedMealsGuest(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var closedBookingsGuest = await bookingService.GetMealsForArchiveAsync(id);
            var closedBookingGuestView = _mapper.Map<List<BookingViewModel>>(closedBookingsGuest);
            ViewBag.Guest = closedBookingGuestView;

            return await Task.Run(() => View());
        }
        public async Task<IActionResult> ArchivedMealsUser()
        {

            var closedBookingsUser = await bookingService.GetBookingsAsync("Closed", false);
            var closedBookingUserView = _mapper.Map<List<BookingViewModel>>(closedBookingsUser);
            ViewBag.User = closedBookingUserView;


            return await Task.Run(() => View());
        }
        [HttpGet]
        public async Task<IActionResult> CloseGuestAsync(int? id)
        {


            if (id == null) return RedirectToAction("Index");
            var getBookingGuest = await bookingService.GetOneBookingGuestAsync(id);
            var getBookingGuestView = _mapper.Map<List<BookingViewModel>>(getBookingGuest);

            ViewBag.GuestId = id;

            var tableId = getBookingGuestView.Select(tableId => tableId.TableId).FirstOrDefault().ToString();
            ViewBag.TableId = tableId;

            return await Task.Run(() => View());
        }
        [HttpPost, ActionName("CloseGuest")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CloseConfirmedGuestAsync(int guestId, int tableId)
        {

            await bookingService.CloseReservationGuest(guestId, tableId);

            return RedirectToAction("Index");

        }
        [HttpGet]

        public async Task<IActionResult> CloseUserAsync(string id)
        {


            if (id == null) return RedirectToAction("Index");

            var getBookingUser = await bookingService.GetOneBookingUserAsync(id);

            ViewBag.UserId = id;

            var tableId = getBookingUser.Select(tableId => tableId.TableId).FirstOrDefault().ToString();
            ViewBag.TableId = tableId;

            return await Task.Run(() => View());
        }
        [HttpPost, ActionName("CloseUser")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CloseConfirmedUserAsync(string userId, int tableId)
        {

            await bookingService.CloseReservationUser(userId, tableId);

            return RedirectToAction("Index");

        }
        [HttpGet]

        public async Task<IActionResult> MealsReadyAsync(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var getBookingMeal = await mealService.GetBookingForMeals(id);
            var mappedBookingMeal = _mapper.Map<List<BookingViewModel>>(getBookingMeal);
            ViewBag.BookingId = id;
            ViewBag.BookingMeals = mappedBookingMeal;

            var mealGet = await mealService.GetMealsAsync();
            ViewBag.Meal = mealGet;

            return await Task.Run(() => View());
        }
        [HttpPost, ActionName("MealsReadyAsync")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MealsReadyAsync(int Id, IEnumerable<int> mealId, IEnumerable<int> amount)
        {

            await mealService.CreateMealAsync(Id, mealId, amount);
            return RedirectToAction("MealsReady", "Waiter", new { @id = Id });


        }
        [HttpPost, ActionName("MealsReadyCheckedAsync")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MealsReadyCheckedAsync(int Id, IEnumerable<int> mealId)
        {

            await mealService.UpdateStatusMealAsync(Id, mealId);
            return RedirectToAction("MealsReady", "Waiter", new { @id = Id });

        }
    }
}
