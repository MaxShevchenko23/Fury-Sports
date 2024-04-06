using AutoMapper;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.Filter;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_bll.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ProductService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ProductFullGet> AddAsync(ProductPost model)
        {
            var entity = mapper.Map<Product>(model);
            var created = await unitOfWork.ProductRepository.CreateAsync(entity);

            return mapper.Map<ProductFullGet>(created);
        }

        public async Task<bool> DeleteAsync(ProductUpdate model)
        {
            try
            {
                var entity = mapper.Map<Product>(model);
                await unitOfWork.ProductRepository.DeleteAsync(entity);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(int modelId)
        {
            try
            {
                await unitOfWork.ProductRepository.DeleteAsync(modelId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductFullGet>> GetAllAsync()
        {
            var entities = await unitOfWork.ProductRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<ProductFullGet>(e));
        }

        public async Task<ProductFullGet> GetByIdAsync(int id)
        {
            var entity = await unitOfWork.ProductRepository.GetAsync(id);
            var specs = await unitOfWork.SpecificationRepository.GetByProductId(id);

            ProductFullGet model = mapper.Map<ProductFullGet>(entity);
            model.Specifications = specs.Select(mapper.Map<SpecificationGet>);
            return model;
        }
        public async Task<ProductShortGet> GetByIdAsyncShort(int id)
        {
            var entity = await unitOfWork.ProductRepository.GetAsync(id);
            return mapper.Map<ProductShortGet>(entity);
        }

        public async Task<IEnumerable<ProductFullGet>> GetFiltered(string? name, int? categoryId, int? manufacturerId, string? description,
            decimal? minPrice, decimal? maxPrice, int? quantity, int pageSize, int pageNumber, IEnumerable<SpecificationFilter>? specs)
        {
            //list to pass in method, if no specs given - an empty list will be passed
            List<Specification>? specsEntities = new();

            if (specs != null)
            {
                specsEntities = specs.Select(e => mapper.Map<Specification>(e)).ToList();
            }

            var entities = await unitOfWork.ProductRepository.Filter(name, categoryId, manufacturerId, description, minPrice, maxPrice, quantity, specsEntities,pageSize, pageNumber);
            return entities.Select(e=>mapper.Map<ProductFullGet>(e));
        }

        public async Task<ProductFullGet> UpdateAsync(ProductUpdate model, int id)
        {
            var entity = mapper.Map<Product>(model);
            entity.Id = id;
            var updated = unitOfWork.ProductRepository.Update(entity);

            return mapper.Map<ProductFullGet>(updated);

        }
    }
}
