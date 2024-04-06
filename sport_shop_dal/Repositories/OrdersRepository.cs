using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class OrdersRepository: IOrderRepository
    {
        private readonly FurySportsContext context;

        public OrdersRepository(FurySportsContext context)
        {
            this.context = context;
        }
        public async Task<Order?> CreateAsync(Order source)
        {
            var entity = await context.Orders.AddAsync(source);
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            await context.Orders.Where(e => e.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync(true);
        }

        public async Task DeleteAsync(Order source)
        {
            context.Orders.Remove(source);
            await context.SaveChangesAsync(true);
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await context.Orders.ToListAsync();
        }

        public async Task<Order?> GetAsync(int id)
        {
            return await context.Orders.FindAsync(id);
        }

        public Order Update(Order source)
        {
            var entity = context.Orders.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }
    }
}
