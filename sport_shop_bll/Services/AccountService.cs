using AutoMapper;
using Newtonsoft.Json.Serialization;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;
using sport_shop_dal.Interfaces;

namespace sport_shop_bll.Services
{
    public class AccountService : IAccountService
    {

        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AccountService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AccountGet> AddAsync(AccountPost model)
        {

            var entity = mapper.Map<Account>(model);
            var created = await unitOfWork.AccountRepository.CreateAsync(entity);
            return mapper.Map<AccountGet>(created);
        }

        public async Task<AccountGet> AuthorizateAsync(AccountPost model)
        {
            var entity = await unitOfWork.AccountRepository.Authorizate(mapper.Map<Account>(model));
            return mapper.Map<AccountGet>(entity);
        }

        public async Task<bool> DeleteAsync(AccountUpdate model)
        {
            try
            {
                await unitOfWork.AccountRepository.DeleteAsync(mapper.Map<Account>(model));
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
                await unitOfWork.AccountRepository.DeleteAsync(modelId);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<AccountGet>> GetAllAsync()
        {
            var entities = await unitOfWork.AccountRepository.GetAllAsync();
            return entities.Select(e => mapper.Map<AccountGet>(e));
        }


        public async Task<AccountGet?> GetByIdAsync(int id)
        {
            return mapper.Map<AccountGet>(await unitOfWork.AccountRepository.GetAsync(id));
        }

        public async Task<AccountGet?> UpdateAsync(AccountUpdate model, int id)
        {
            var entity = mapper.Map<Account>(model);
            entity.Id = id;
            var updated = unitOfWork.AccountRepository.Update(entity);

            return mapper.Map<AccountGet>(updated);
        }
    }
}

