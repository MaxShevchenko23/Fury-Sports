using sport_shop_bll.Interfaces;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;

namespace sport_shop_bll.Services
{
    public interface IAccountService:ICrud<AccountPost,AccountGet,AccountUpdate>
    {
        Task<AccountGet> AuthorizateAsync(AccountPost model);
    }
}