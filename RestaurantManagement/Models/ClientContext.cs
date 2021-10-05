using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Bookings> Bookings { get; set; }

        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
