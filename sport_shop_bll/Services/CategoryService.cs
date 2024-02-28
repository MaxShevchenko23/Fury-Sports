using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Data;
using sport_shop_dal.Interfaces;

namespace sport_shop_bll.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public Task<CategoryPost> AddAsync(CategoryPost model)
        {
            
        }

        public Task DeleteByIdAsync(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CategoryGet>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CategoryGet> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CategoryUpdate> UpdateAsync(CategoryUpdate model)
        {
            throw new NotImplementedException();
        }
    }
}
