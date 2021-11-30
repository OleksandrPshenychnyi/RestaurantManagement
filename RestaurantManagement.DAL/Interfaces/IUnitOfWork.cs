﻿using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IBookingRepository Bookings { get; }
        IGuestRepository Guests { get; }
        IGenericRepository<Table> Tables { get; }
        IGenericRepository<User> Users { get; }
    }
}
