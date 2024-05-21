using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly FurySportsContext context;

        public CartRepository(FurySportsContext context)
        {
            this.context = context;
        }
        public async Task<Cart?> CreateAsync(Cart source)
        {
            var entity = await context.Carts.AddAsync(source);
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            await context.Carts.Where(e => e.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync(true);
        }

        public async Task DeleteAsync(Cart source)
        {
            context.Carts.Remove(source);
            await context.SaveChangesAsync(true);
        }

        public async Task<IEnumerable<Cart>> GetAllAsync()
        {
            return await context.Carts.ToListAsync();
        }

        public async Task<Cart?> GetAsync(int id)
        {
            return await context.Carts.FindAsync(id);
        }

        public Cart Update(Cart source)
        {
            var entity = context.Carts.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }

        public async Task<(IEnumerable<Product>, decimal)> GetProductsAndSumByAccountIdAsync(int accountId)
        {
            List<int> ids = new();
            decimal sumToReturn = 0;


            var idAndPrice =
                            from p in context.Products
                            join c in context.Carts on p.Id equals c.ProductId into pc
                            from cartItem in pc.DefaultIfEmpty()
                            where cartItem != null && cartItem.AccountId == 3
                            select new
                            {
                                ProductId = p.Id,
                                Price = p.Price
                            };

           
            await idAndPrice.ForEachAsync(e =>
            {
                ids.Add(e.ProductId);
                sumToReturn += e.Price;
            });


            IEnumerable<Product> productsToReturn = context.Products.Where(e => ids.Contains(e.Id));

            return (productsToReturn,sumToReturn);

        }
    }
}
