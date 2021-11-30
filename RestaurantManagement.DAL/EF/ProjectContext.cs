
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.Enteties;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.EF
{
    public class ProjectContext : IdentityDbContext<User>
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Meal> Meals { get; set; }    
        public DbSet<Table> Tables { get; set; }
        public DbSet<CartItem> ShoppingCartItems { get; set; }
        public DbSet<Booking_Meal> Booking_Meals { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
            .HasOne(n => n.User)
            .WithMany(a => a.Bookings);

            modelBuilder.Entity<Booking>()
                .HasOne(p => p.Guest)
                .WithOne(b => b.Booking);

            modelBuilder.Entity<Booking>()
                .HasOne(p => p.Table)
                .WithMany(b => b.Bookings);

            modelBuilder.Entity<Booking_Meal>()
                .HasOne(p => p.Meal)
                .WithMany(b => b.Booking_Meals)
                .HasForeignKey(pt => pt.MealId);
            modelBuilder.Entity<Booking_Meal>()
                .HasOne(p => p.Booking)
                .WithMany(b => b.Booking_Meals)
                .HasForeignKey(pt => pt.BookingId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
