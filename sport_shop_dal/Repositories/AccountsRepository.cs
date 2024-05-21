using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Data;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_dal.Repositories
{
    public class AccountsRepository : IAccountRepository
    {
        private readonly FurySportsContext context;

        public AccountsRepository(FurySportsContext context)
        {
            this.context = context;
        }

        public async Task<Account?> Authorizate(Account source)
        {
            Account? entity = await context.Accounts.FirstOrDefaultAsync(e => e.Email == source.Email && e.PhoneNumber == source.PhoneNumber);
            if (entity==null)
            {
                return await CreateAsync(source);               
            }
            return entity;
        }

        public async Task<Account?> CreateAsync(Account source)
        {
            var entity = await context.Accounts.AddAsync(source);
            await context.SaveChangesAsync(true);
            return entity.Entity;
        }

        public async Task DeleteAsync(int id)
        {
            await context.Accounts.Where(e => e.Id == id).ExecuteDeleteAsync();
            await context.SaveChangesAsync(true);
        }

        public async Task DeleteAsync(Account source)
        {
            context.Accounts.Remove(source);
            await context.SaveChangesAsync(true);
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await context.Accounts.ToListAsync();
        }

        public async Task<Account?> GetAsync(int id)
        {
            return await context.Accounts.SingleAsync(e => e.Id == id);
        }

        public Account Update(Account source)
        {
            var entity = context.Accounts.Update(source);
            context.SaveChanges(true);
            return entity.Entity;
        }
    }
}
