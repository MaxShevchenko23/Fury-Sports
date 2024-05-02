using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_bll.Interfaces
{
    public interface IOrdersService:ICrud<OrderPost,OrderGet,OrderUpdate>
    {
    }
}
