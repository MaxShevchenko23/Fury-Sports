﻿using AutoMapper;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
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
        public async Task<CategoryGet> AddAsync(CategoryPost model)
        {
            var entity = mapper.Map<Category>(model);
            var created = await unitOfWork.CategoryRepository.CreateAsync(entity);
            return mapper.Map<CategoryGet>(created);
        }

        public async Task<bool> DeleteAsync(CategoryUpdate model)
        {
            try
            {
                await unitOfWork.CategoryRepository.DeleteAsync(mapper.Map<Category>(model));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteByIdAsync(int modelId)
        {
            try
            {
                await unitOfWork.CategoryRepository.DeleteAsync(modelId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<CategoryGet>> GetAllAsync()
        {
            var entities = await unitOfWork.CategoryRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<CategoryGet>(e));
        }

        public async Task<CategoryGet?> GetByIdAsync(int id)
        {
            return mapper.Map<CategoryGet>(await unitOfWork.CategoryRepository.GetAsync(id));
        }

        public async Task<CategoryGet?> UpdateAsync(CategoryUpdate model)
        {
            var entity = mapper.Map<Category>(model);
            var updated = unitOfWork.CategoryRepository.Update(entity);
            
            return mapper.Map<CategoryGet>(updated);
        }
    }
}
