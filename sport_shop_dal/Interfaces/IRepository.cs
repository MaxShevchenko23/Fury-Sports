using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Entities;

namespace sport_shop_dal.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> CreateAsync(T source);
        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        T Update(T source);
        Task DeleteAsync(int id);
        Task DeleteAsync(T source);
    }
}
