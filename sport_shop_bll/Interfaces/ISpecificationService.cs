using AutoMapper.Configuration.Conventions;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;


namespace sport_shop_bll.Interfaces
{
    public interface ISpecificationService : ICrud<SpecificationPost, SpecificationGet, SpecificationUpdate>
    {
        Task<IEnumerable<SpecificationGet>> GetSpecificationsByProductIdAsync(int productId);
        Task<IEnumerable<SpecificationGet>> GetSpecificationsForProductsInCategoryAsync(int categoryId);

    }
}
