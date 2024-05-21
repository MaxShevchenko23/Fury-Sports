using sport_shop_dal.Entities;

namespace sport_shop_dal.Interfaces
{
    public interface IReviewRepository:IRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByProdIdAsync(int id);
    }
}