using AutoMapper;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_bll.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public ReviewService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }
        public async Task<ReviewGet> AddAsync(ReviewPost model)
        {
            var entity = mapper.Map<Review>(model);
            entity.Date = DateTime.Now;
            var created = await unitOfWork.ReviewRepository.CreateAsync(entity);

            return mapper.Map<ReviewGet>(created);
        }

        public async Task<bool> DeleteAsync(ReviewUpdate model)
        {
            //проверить 
            try
            {
                var entity = mapper.Map<Review>(model);
                await unitOfWork.ReviewRepository.DeleteAsync(entity);

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
                await unitOfWork.ReviewRepository.DeleteAsync(modelId);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ReviewGet>> GetAllAsync()
        {
            var entities = await unitOfWork.ReviewRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<ReviewGet>(e));
        }

        public async Task<ReviewGet> GetByIdAsync(int id)
        {
            var entity = await unitOfWork.ReviewRepository.GetAsync(id);

            return mapper.Map<ReviewGet>(entity);
        }


        public async Task<ReviewGet> UpdateAsync(ReviewUpdate model, int id)
        {
            var entity = mapper.Map<Review>(model);
            entity.Id = id;
            var updated = unitOfWork.ReviewRepository.Update(entity);

            return mapper.Map<ReviewGet>(updated);

        }

        public async Task<IEnumerable<ReviewGet>?> GetByProductIdAsync(int id)
        {
            var entities = await unitOfWork.ReviewRepository.GetReviewsByProdIdAsync(id);

            return entities.Select(mapper.Map<ReviewGet>);
        }

    }
}

