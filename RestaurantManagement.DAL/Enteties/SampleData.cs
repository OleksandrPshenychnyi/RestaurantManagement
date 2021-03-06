using Microsoft.AspNetCore.Identity;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagement
{
    public enum Roles
    {
        Admin,
        Waiter,
        User
    }

    public class SampleData
    {
        public static async Task SeedRolesAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Waiter.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

        }
        public static async Task DefaultUserInit(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {

            var DefaultAdmin = new User
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FirstName = "admin",
                SecondName = "nimda",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != DefaultAdmin.Id))
            {
                var user = await userManager.FindByEmailAsync(DefaultAdmin.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(DefaultAdmin, "Admin1!");
                    await userManager.AddToRoleAsync(DefaultAdmin, Roles.Admin.ToString());

                }

            }
            var DefaultUser = new User
            {
                UserName = "user1@gmail.com",
                Email = "user1@gmail.com",
                FirstName = "Alex",
                SecondName = "Pshen",
                PhoneNumber = "123456",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true

            };
            if (userManager.Users.All(u => u.Id != DefaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(DefaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(DefaultUser, "User1!");
                    await userManager.AddToRoleAsync(DefaultUser, Roles.User.ToString());
                }
            }
            var DefaultWaiter = new User
            {
                UserName = "waiter1@gmail.com",
                Email = "waiter1@gmail.com",
                FirstName = "waiter",
                SecondName = "retiaw",
                PhoneNumber = "123456",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != DefaultWaiter.Id))
            {
                var user = await userManager.FindByEmailAsync(DefaultWaiter.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(DefaultWaiter, "Waiter1!");
                    await userManager.AddToRoleAsync(DefaultWaiter, Roles.Waiter.ToString());
                }
            }
        }
        public static void Initialize(ProjectContext context)
        {

            if (!context.Meals.Any())
            {
                context.Meals.AddRange(
                    new Meal
                    {
                        MealName = "Uzvar",
                        Description = "Made with apples",
                        ImagePath = "uzvar.jpg",
                        UnitPrice = 15.50M,
                        Category = "Drinks"

                    },
                    new Meal
                    {
                        MealName = "Borshch",
                        Description = "Red like blood",
                        ImagePath = "borshch.jpg",
                        UnitPrice = 20m,
                        Category = "Soups"

                    },
                    new Meal
                    {
                        MealName = "Shashlik",
                        Description = "You like it eji",
                        ImagePath = "shashlik.jpg",
                        UnitPrice = 50m,
                        Category = "Cooked on grill"

                    }
                );
                context.SaveChanges();
            }
            if (!context.Tables.Any())
            {
                context.Tables.AddRange(
                    new Table
                    {
                        TableNumber = 5,
                        Capacity = 3,
                        HallPlacing = "Non smoking",
                        IsAvailable = true,
                        TablePrice = 30,
                        TableDiscount = 10m

                    },
                    new Table
                    {
                        TableNumber = 2,
                        Capacity = 5,
                        HallPlacing = "Smoking",
                        IsAvailable = true,
                        TablePrice = 40,
                        TableDiscount = 20m
                    },
                    new Table
                    {
                        TableNumber = 8,
                        Capacity = 3,
                        HallPlacing = "Non smoking",
                        IsAvailable = true,
                        TablePrice = 60,
                        TableDiscount = 30m

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
