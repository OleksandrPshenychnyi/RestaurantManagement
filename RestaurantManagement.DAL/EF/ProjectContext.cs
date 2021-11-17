﻿
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.Models;
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
        //public DbSet<Course> Courses { get; set; }
       // public DbSet<Employee> Employees { get; set; }
      //  public DbSet<Order> Orders { get; set; }
        public DbSet<Table> Tables { get; set; }
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
            base.OnModelCreating(modelBuilder);
        }
    }
}