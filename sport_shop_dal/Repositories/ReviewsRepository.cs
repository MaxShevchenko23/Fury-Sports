using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class ReviewsRepository : IReviewRepository
    {
        private readonly FurySportsContext context;

        public ReviewsRepository(FurySportsContext context)
        {
            this.context = context;
        }
        public async Task<Review?> CreateAsync(Review source)
        {
            var entity = await context.Reviews.AddAsync(source);
            await context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Reviews.Where(e => e.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync(true);
        }

        public async Task DeleteAsync(Review source)
        {
            context.Reviews.Where(e => e.Id == source.Id).ExecuteDeleteAsync();
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            var entities = await context.Reviews.ToListAsync();
            return entities;
        }

        public async Task<Review?> GetAsync(int id)
        {
            var entity = await context.Reviews.SingleAsync(e => e.Id == id);
            return entity;

        }

        public async Task<IEnumerable<Review>> GetReviewsByProdIdAsync(int id)
        {
            var entities = context.Reviews.Where(e => e.ProductId == id).AsEnumerable();
            return entities.AsEnumerable();
        }

        public Review Update(Review source)
        {
            var entity = context.Reviews.Update(source);
            context.SaveChanges(true);

            return entity.Entity;
        }
    }
}
