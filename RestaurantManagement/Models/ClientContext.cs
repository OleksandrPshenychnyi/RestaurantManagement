using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.Models
{
    public class ClientContext :IdentityDbContext<User>
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<Course> Courses { get; set; }
       // public DbSet<Employee> Employees { get; set; }
      //  public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
        public ClientContext(DbContextOptions<ClientContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasOne(p => p.Client)
                .WithMany(b => b.Bookings);

            modelBuilder.Entity<Booking>()
                .HasOne(p => p.Table)
                .WithMany(b => b.Bookings);
            base.OnModelCreating(modelBuilder);
        }
    }
}
