using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class SpecificationRepository : ISpecificationRepository
    {
        private readonly FurySportsContext context;

        public SpecificationRepository(FurySportsContext context)
        {
            this.context = context;
        }

        public async Task<Specification?> CreateAsync(Specification source)
        {
            if (source.SpecificationValue == "del")
            {
                context.Specifications.Remove(await context.Specifications.FirstAsync(e => e.SpecificationName == source.SpecificationName));
                return new();
            }

            var entity = await context.Specifications.AddAsync(source);
            await context.SaveChangesAsync(true);
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Specifications.FindAsync(id) ?? throw new DBException($"Record with meantioned id={id} was not found");
            context.Specifications.Remove(entity);
            await context.SaveChangesAsync(true);
        }

        public async Task DeleteAsync(Specification source)
        {
            context.Specifications.Remove(source);
            await context.SaveChangesAsync(true);
        }

        public async Task<IEnumerable<Specification>> GetAllAsync()
        {
            return await context.Specifications.ToListAsync();
        }

        public async Task<Specification?> GetAsync(int id)
        {
            return await context.Specifications.FindAsync(id);
        }

        public async Task<IEnumerable<Specification>> GetByProductId(int productId)
        {
            return await context.Specifications.Where(e => e.ProductId == productId).ToListAsync();
        }

        public Specification Update(Specification source)
        {
            var entity = context.Specifications.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }
    }
}
