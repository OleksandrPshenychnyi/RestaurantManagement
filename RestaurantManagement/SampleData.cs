using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement
{
    public class SampleData
    {
        public static void Initialize(ClientContext context)
        {
            if (!context.Bookings.Any())
            {
                context.Bookings.AddRange(
                    new Bookings
                    {
                        TableNumber = 5,
                        Capacity = 3,
                        HallPlacing = "Non smoking",
                        IsAvailable = true
                        
                    },
                    new Bookings
                    {
                        TableNumber = 2,
                        Capacity = 5,
                        HallPlacing = "Smoking",
                        IsAvailable = false
                        
                    },
                    new Bookings
                    {
                        TableNumber = 8,
                        Capacity = 3,
                        HallPlacing = "Non smoking",
                        IsAvailable = true
                        
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
