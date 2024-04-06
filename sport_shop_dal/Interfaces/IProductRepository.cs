using sport_shop_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_dal.Interfaces
{
    public interface IProductRepository:IRepository<Product>
    {
      
        Task<IEnumerable<Product>?> Filter(string? name, int? categoryId, int? manufacturerId, string? description, decimal? minPrice, decimal? maxPrice, int? quantity, IEnumerable<Specification>? specs, int pageSize,
            int pageNumber);
        Task<IEnumerable<Product>> GetAllDecreasingAsync();
    }
}
