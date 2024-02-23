using Microsoft.EntityFrameworkCore;
using sport_shop_dal.Entities;

namespace sport_shop_dal.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T?> Create(T source);
        Task<T?> Get(int id);
        T Update(T source);
        Task DeleteAsync(int id);
        void Delete(T source);
    }
}
