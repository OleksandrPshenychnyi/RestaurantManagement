﻿using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.EF;
using RestaurantManagement.DAL.Enteties;
using RestaurantManagement.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.Repositories
{
    public class MealRepository : GenericRepository<Meal>, IMealRepository
    {

        private ProjectContext db;

        public MealRepository(ProjectContext context) : base(context)
        {
            db = context;

        }
        public  async Task<IEnumerable<Meal>> GetAllMealsAsync()
        {

            return await db.Meals.ToListAsync();
        }
        public async Task<Meal> GetOneMealAsync(int? id)
        {

            return await db.Meals.FindAsync(id); ;
        }
        public  async Task CreateMealAsync(Meal meal)
        {
            await db.AddAsync(meal);
            await db.SaveChangesAsync();
        }
        public override async Task UpdateAsync(Meal meal)
        {
            db.Entry(meal).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public override async Task DeleteAsync(int id)
        {
            var meal = await db.Meals.FindAsync(id);
            if (meal != null)
                db.Remove(meal);
            await db.SaveChangesAsync();
        }
        public async Task<bool> Exists(int id)
        {
            return await db.Meals.AnyAsync(e => e.MealId == id);
        }
    }
}
