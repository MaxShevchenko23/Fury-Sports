using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class OrdersRepository : IOrderRepository
    {
        private readonly FurySportsContext context;

        public OrdersRepository(FurySportsContext context)
        {
            this.context = context;
        }

        public async Task<Order> ChangeStatusAsync(int orderId, int statusCode)
        {
            context.Orders.Where(e=>e.Id==orderId).ExecuteUpdate(e => e.SetProperty(e => e.Status, statusCode));
            var entity = await context.Orders.SingleOrDefaultAsync(e=>e.Id==orderId);
            
            return entity;
        }

        public async Task<Order?> CreateAsync(Order source)
        {
            if (source.Quantity >= context.Products.First(e => e.Id == source.ProductId).Quantity)                
            {
                throw new DBException("There is not enough products left in stock");
            }

            if (source.Quantity <= 0)
            {
                throw new DBException("The quantity cannot be less than zero");                
            }


            source.Date = DateTime.Now;

            if (source.ClientPhoneNumber.StartsWith('+'))
            {
                source.ClientPhoneNumber = source.ClientPhoneNumber.Substring(1);
            }
            source.Status = 0;

            //return new Order();

            var entity = await context.Orders.AddAsync(source);
            var updated = await context.Products.Where(e => e.Id == source.ProductId)
                .ExecuteUpdateAsync(e => e.SetProperty(p => p.Quantity, p => p.Quantity - source.Quantity));

            await context.SaveChangesAsync(true);
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
            return await context.Orders.Include(e=>e.Product).ToListAsync();
        }

        public async Task<Order?> GetAsync(int id)
        {
            return await context.Orders.FindAsync(id);
        }

        public async Task<IEnumerable<Order>> GetByUserId(int userId)
        {
            return await context.Orders.Where(e => e.AccountId == userId).Include(e=>e.Product).ToListAsync();
        }

        public Order Update(Order source)
        {
            var entity = context.Orders.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }
    }
}
