﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;


namespace sport_shop_dal.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly FurySportsContext context;

        public CategoryRepository(FurySportsContext context)
        {
            this.context = context;
        }
        public async Task<Category?> CreateAsync(Category source)
        {
            var entity = await context.Categories.AddAsync(source);
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            await context.Categories.Where(e => e.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync(true);
        }

        public async Task DeleteAsync(Category source)
        {
            context.Categories.Remove(source);
            await context.SaveChangesAsync(true);
        }

        public async Task<IEnumerable<Category>?> Filter(string? name, int? rootCategoryId)
        {
            return await context.Categories.Where(e=>e.Name.Contains(name) || e.RootCategoryId==rootCategoryId).ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await context.Categories.ToListAsync();
        }

        public async Task<Category?> GetAsync(int id)
        {
            return await context.Categories.FindAsync(id);
        }

        public Category Update(Category source)
        {
            var entity = context.Categories.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }

        
    }
}
