using sport_shop_bll.Models.Filter;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;

namespace sport_shop_bll.Interfaces
{
    public interface IProductService : ICrud<ProductPost, ProductFullGet, ProductUpdate>
    {
        Task<IEnumerable<ProductFullGet>> GetFiltered(string? name, int? categoryId, int? manufacturerId,
            string? description, decimal? minPrice, decimal? maxPrice, int? quantity, int pageSize,
            int pageNumber, IEnumerable<SpecificationFilter>? specs);
    }
}
