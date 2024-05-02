using sport_shop_dal.Entities;

namespace sport_shop_dal.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> ChangeStatusAsync(int orderId, int statusCode);
        Task<IEnumerable<Order>> GetByUserId(int userId);
    }
}