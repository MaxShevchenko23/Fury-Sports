using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;

namespace sport_shop_bll.Interfaces
{
    public interface IManufacturerService : ICrud<ManufacturerPost, ManufacturerGet, ManufacturerUpdate>
    {
    }
}
