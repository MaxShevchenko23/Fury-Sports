using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_bll.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ManufacturerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ManufacturerGet> AddAsync(ManufacturerPost model)
        {
            var entity = mapper.Map<Manufacturer>(model);
            var created = await unitOfWork.ManufacturerRepository.CreateAsync(entity);

            return mapper.Map<ManufacturerGet>(created);
        }
        public async Task<bool> DeleteAsync(ManufacturerUpdate model)
        {
            try
            {
                var entity = mapper.Map<Manufacturer>(model);
                await unitOfWork.ManufacturerRepository.DeleteAsync(entity);

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
                await unitOfWork.ManufacturerRepository.DeleteAsync(modelId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ManufacturerGet>> GetAllAsync()
        {
            var entities = await unitOfWork.ProductRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<ManufacturerGet>(e));
        }

        public async Task<ManufacturerGet> GetByIdAsync(int id)
        {
            var entity = await unitOfWork.ManufacturerRepository.GetAsync(id);
            return mapper.Map<ManufacturerGet>(entity);
        }

        public async Task<ManufacturerGet> UpdateAsync(ManufacturerUpdate model,  int id)
        {
            var entity = mapper.Map<Manufacturer>(model);
            entity.Id = id;
            var updated = unitOfWork.ManufacturerRepository.Update(entity);

            return mapper.Map<ManufacturerGet>(updated);
        }
    }
}
