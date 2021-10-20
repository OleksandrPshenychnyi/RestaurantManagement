using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class ClientContext : IdentityDbContext<User>
    {
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Bookings>()
        //        .HasOne(p => p.Clients)
        //        .WithMany(b => b.Bookings);
        //}
    }
}
