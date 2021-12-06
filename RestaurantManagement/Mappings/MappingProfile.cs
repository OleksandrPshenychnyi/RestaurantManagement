using AutoMapper;
using RestaurantManagement.BLL;
using RestaurantManagement.BLL.DTO;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
    {
            CreateMap<Table, TableViewModel>();
            CreateMap<Table, TableDTO>();
            CreateMap<TableDTO, TableViewModel>();
            CreateMap<GuestViewModel, GuestDTO>();
            CreateMap<Guest, GuestDTO>();
            CreateMap<GuestDTO, Guest>();
            CreateMap<GuestDTO, GuestViewModel>();
            CreateMap<Booking, BookingDTO>()
                .IncludeMembers(m => m.Guest) ;
                
            CreateMap<Guest, BookingDTO>(MemberList.None);
            CreateMap<BookingDTO, BookingViewModel>()
            .IncludeMembers(m => m.Guest);
            CreateMap<GuestDTO, BookingViewModel>();
            CreateMap<Guest, BookingViewModel>(MemberList.None);
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, UserViewModel>();
        }
   
        
    }
}
