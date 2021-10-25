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
           
            if (!context.Tables.Any())
            {
                context.Tables.AddRange(
                    new Table
                    {
                        TableNumber = 5,
                        Capacity = 3,
                        HallPlacing = "Non smoking",
                        WaiterId = 1,
                        IsAvailable = true


                    },
                    new Table
                    {
                        TableNumber = 2,
                        Capacity = 5,
                        HallPlacing = "Smoking",
                        WaiterId = 2,
                        IsAvailable = false


                    },
                    new Table
                    {
                        TableNumber = 8,
                        Capacity = 3,
                        HallPlacing = "Non smoking",
                        WaiterId = 3,
                        IsAvailable = true


                    }
                );
                context.SaveChanges();
            }
            if (!context.Clients.Any())
            {
                context.Clients.AddRange(
                    new Client
                    {

                        FirstName = "dada",
                        SecondName = "dada",
                        PhoneNumber = 3123123,
                        TableNumber = 3

                    }

                );
                context.SaveChanges();
            }
            if (!context.Bookings.Any())
            {
                context.Bookings.AddRange(
                    new Booking
                    {

                        TableId = 1,
                        
                        ClientId = 1

                    },
                    new Booking
                    {

                        TableId =2,
                        
                        ClientId = 1

                    },
                    new Booking
                    {

                        TableId = 3,
                        
                        ClientId = 1

                    }
                );
                context.SaveChanges();
            }
        }
    }
}

