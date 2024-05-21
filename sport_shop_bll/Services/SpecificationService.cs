using AutoMapper;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Services
{
    public class SpecificationService : ISpecificationService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public SpecificationService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<SpecificationGet> AddAsync(SpecificationPost model)
        {
            var entity = mapper.Map<Specification>(model);
            var created = await unitOfWork.SpecificationRepository.CreateAsync(entity);

            return mapper.Map<SpecificationGet>(created);
        }

        public async Task<bool> DeleteAsync(SpecificationUpdate model)
        {
            try
            {
                var entity = mapper.Map<Specification>(model);
                await unitOfWork.SpecificationRepository.DeleteAsync(entity);

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
                await unitOfWork.SpecificationRepository.DeleteAsync(modelId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SpecificationGet>> GetAllAsync()
        {
            var entities = await unitOfWork.SpecificationRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<SpecificationGet>(e));
        }

        public async Task<SpecificationGet> GetByIdAsync(int id)
        {
            var entity = await unitOfWork.SpecificationRepository.GetAsync(id);
            return mapper.Map<SpecificationGet>(entity);

        }

        public async Task<IEnumerable<SpecificationGet>> GetSpecificationsByProductIdAsync(int productId)
        {
            var entity = await unitOfWork.SpecificationRepository.GetByProductId(productId);

            return entity.Select(mapper.Map<SpecificationGet>);
        }

        public Task<IEnumerable<SpecificationGet>> GetSpecificationsForProductsInCategoryAsync(int categoryId)
        {
            throw new NotImplementedException();
        }

        public async Task<SpecificationGet> UpdateAsync(SpecificationUpdate model, int id)
        {
            var entity = mapper.Map<Specification>(model);
            entity.Id = id;
            var updated = unitOfWork.SpecificationRepository.Update(entity);

            return mapper.Map<SpecificationGet>(updated);
        }
    }
}
