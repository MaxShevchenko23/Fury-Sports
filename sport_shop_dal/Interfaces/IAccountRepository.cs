using sport_shop_dal.Entities;

namespace sport_shop_dal.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Task<Account?> Authorizate(Account source);
    }
}