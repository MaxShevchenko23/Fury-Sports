using sport_shop_dal.Entities;

namespace sport_shop_dal.Interfaces
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<(IEnumerable<Product>, decimal)> GetProductsAndSumByAccountIdAsync(int accountId);
    }
}