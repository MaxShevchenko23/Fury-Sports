using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly FurySportsContext context;

        public ManufacturerRepository(FurySportsContext context)
        {
            this.context = context;
        }
        public async Task<Manufacturer?> CreateAsync(Manufacturer source)
        {
            var entity = await context.Manufacturers.AddAsync(source);
            await context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Products.FindAsync(id);

            context.Products.Remove(entity);
            await context.SaveChangesAsync(true);

        }

        public async Task DeleteAsync(Manufacturer source)
        {
            context.Manufacturers.Remove(source);
            await context.SaveChangesAsync(true);
        }

        public async Task<IEnumerable<Manufacturer>?> Filter(string? name, string? country, int? mainCategoryId)
        {
            IQueryable<Manufacturer> entities = context.Manufacturers.AsQueryable();

            if (!name.IsNullOrEmpty())
            {
                name.Trim();
                entities = entities.Where(e => e.Name.Contains(name));
            }

            if (!country.IsNullOrEmpty())
            {
                country.Trim();
                entities = entities.Where(e => e.Country.Contains(name));
            }

            if (mainCategoryId.HasValue)
            {
                entities = entities.Where(e => e.MainCategoryId == mainCategoryId);
            }

            return entities;
        }

        public async Task<IEnumerable<Manufacturer>> GetAllAsync()
        {
            return await context.Manufacturers.ToListAsync();
        }

        public async Task<Manufacturer?> GetAsync(int id)
        {
            return await context.Manufacturers.FindAsync(id);
        }

        public Manufacturer Update(Manufacturer source)
        {
            var entity = context.Manufacturers.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }
    }
}
