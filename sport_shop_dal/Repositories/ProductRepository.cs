using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly SportshopdbContext context;

        public ProductRepository(SportshopdbContext context)
        {
            this.context = context;
        }

        public async Task<Product?> Create(Product source)
        {
            var entity = await context.Products.AddAsync(source);
            await context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Products.FindAsync(id) ?? throw new DBException($"Record with meantioned id={id} was not found");
            context.Products.Remove(entity);
            await context.SaveChangesAsync(true);
        }

        public void Delete(Product source)
        {
            context.Products.Remove(source);
            context.SaveChangesAsync(true);
        }

        public async Task<Product?> Get(int id)
        {
            return await context.Products.FindAsync(id);
        }

        public Product Update(Product source)
        {
            var entity = context.Products.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }
    }
}
