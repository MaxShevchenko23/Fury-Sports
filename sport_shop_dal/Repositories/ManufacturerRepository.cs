using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;


namespace sport_shop_dal.Repositories
{
    public class ManufacturerRepository : IManufacturerRepository
    {
        private readonly SportshopdbContext context;

        public ManufacturerRepository(SportshopdbContext context)
        {
            this.context = context;
        }
        public async Task<Manufacturer?> Create(Manufacturer source)
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

        public async Task<Manufacturer?> Get(int id)
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
