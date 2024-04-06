using sport_shop_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_dal.Interfaces
{
    public interface IManufacturerRepository:IRepository<Manufacturer>
    {
        Task<IEnumerable<Manufacturer>?> Filter(string? name, string? country, int? mainCategoryId);
    }
}
