using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_dal.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SportshopdbContext context;

        public CategoryRepository(SportshopdbContext context)
        {
            this.context = context;
        }
        public async Task<Category?> Create(Category source)
        {
            var entity = await context.Categories.AddAsync(source);
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Categories.FindAsync(id) ?? throw new DBException($"Record with meantioned id={id} was not found");
            context.Categories.Remove(entity);
            await context.SaveChangesAsync(true);
        }

        public void Delete(Category source)
        {
            context.Categories.Remove(source);
            context.SaveChangesAsync(true);
        }

        public async Task<Category?> Get(int id)
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
