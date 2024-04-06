using sport_shop_dal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sport_shop_dal.Interfaces
{
    public interface ISpecificationRepository:IRepository<Specification>
    {
        Task<IEnumerable<Specification>> GetByProductId(int productId);
    }
}
