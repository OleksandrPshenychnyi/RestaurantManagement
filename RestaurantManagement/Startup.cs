using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantManagement.BLL.Interfaces;
using RestaurantManagement.BLL.Services;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using RestaurantManagement.DAL.Repositories;
using RestaurantManagement.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("DefaultConnection");
            
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connection));
            services.AddIdentity<User, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;    //unique email
                opts.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz1234567890"; // symbols
            })
               .AddEntityFrameworkStores<ProjectContext>();
            services.AddControllersWithViews();
            services.AddScoped<IBookingService, BookingService>();
            services.AddScoped<ITableService, TableService>();
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IMealService, MealService>();
            services.AddScoped<IGenericRepository<Table>, GenericRepository<Table>>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IBookings_MealsRepository, Booking_MealRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<IGenericRepository<Guest>, GenericRepository<Guest>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();
            services.AddAuthentication();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Table}/{action=Index}/{id?}");
            });
        }
    }
}
