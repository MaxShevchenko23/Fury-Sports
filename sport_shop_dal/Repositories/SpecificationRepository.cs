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
    public class SpecificationRepository : ISpecificationRepository
    {
        private readonly SportshopdbContext context;

        public SpecificationRepository(SportshopdbContext context)
        {
            this.context = context;
        }

        public async Task<Specification?> Create(Specification source)
        {
            var entity = await context.Specifications.AddAsync(source);
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Specifications.FindAsync(id) ?? throw new DBException($"Record with meantioned id={id} was not found");
            context.Specifications.Remove(entity);
            await context.SaveChangesAsync(true);
        }

        public void Delete(Specification source)
        {
            context.Specifications.Remove(source);
            context.SaveChangesAsync(true);
        }

        public async Task<Specification?> Get(int id)
        {
            return await context.Specifications.FindAsync(id);
        }

        public Specification Update(Specification source)
        {
            var entity = context.Specifications.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }
    }
}
