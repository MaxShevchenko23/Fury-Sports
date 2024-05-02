using AutoMapper;
using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_bll.Services
{
    public class OrderService : IOrdersService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<OrderGet> AddAsync(OrderPost model)
        {

            var entity = mapper.Map<Order>(model);
            var created = await unitOfWork.OrderRepository.CreateAsync(entity);
            await unitOfWork.ProductRepository.PurchasesInc(model.ProductId);
            return mapper.Map<OrderGet>(created);
        }

        public async Task<OrderGet> ChangeStatusAsync(int orderId, int statusCode)
        {
            var changed = await unitOfWork.OrderRepository.ChangeStatusAsync(orderId, statusCode);
            return mapper.Map<OrderGet>(changed);
        }

        public async Task<bool> DeleteAsync(OrderUpdate model)
        {
            try
            {
                await unitOfWork.OrderRepository.DeleteAsync(mapper.Map<Order>(model));
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
                await unitOfWork.OrderRepository.DeleteAsync(modelId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<OrderGet>> GetAllAsync()
        {
            var entities = await unitOfWork.OrderRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<OrderGet>(e));
        }


        public async Task<OrderGet?> GetByIdAsync(int id)
        {
            return mapper.Map<OrderGet>(await unitOfWork.OrderRepository.GetAsync(id));
        }

        public async Task<IEnumerable<OrderGet>> GetByUserId(int userId)
        {
            var entities = await unitOfWork.OrderRepository.GetByUserId(userId);
            return entities.Select(mapper.Map<OrderGet>);
        }

        public async Task<OrderGet?> UpdateAsync(OrderUpdate model, int id)
        {
            var entity = mapper.Map<Order>(model);
            entity.Id = id;
            var updated = unitOfWork.OrderRepository.Update(entity);

            return mapper.Map<OrderGet>(updated);
        }
    }
}
