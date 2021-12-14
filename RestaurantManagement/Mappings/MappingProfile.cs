using AutoMapper;
using RestaurantManagement.BLL;
using RestaurantManagement.BLL.DTO;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;

namespace RestaurantManagement.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
    {
            CreateMap<Table, TableViewModel>();
            CreateMap<Table, TableDTO>();
            CreateMap<TableDTO, TableViewModel>();
            CreateMap<TableDTO, Table>();
            CreateMap<GuestViewModel, GuestDTO>();
            CreateMap<Guest, GuestDTO>();
            CreateMap<GuestDTO, Guest>();
            CreateMap<GuestDTO, GuestViewModel>();
            CreateMap<Guest, GuestViewModel>();
            CreateMap<Booking, BookingViewModel>();
            CreateMap<Booking, BookingDTO>();
            CreateMap<BookingDTO, BookingViewModel>();
            CreateMap<Meal, MealDTO>();
            CreateMap<MealDTO, MealViewModel>();
            CreateMap<Meal, MealViewModel>();
            CreateMap<Booking_Meal, Booking_MealDTO>();
            CreateMap<Booking_MealDTO, Booking_MealViewModel>();
            CreateMap<Booking_Meal, Booking_MealViewModel>();
            CreateMap<MealDTO, Meal>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserViewModel>();
            CreateMap<UserDTO, UserViewModel>();
            CreateMap<UserViewModel, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
