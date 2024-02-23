using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sport_shop_dal.Interfaces;
using sport_shop_dal.Repositories;

namespace sport_shop_dal.Data
{
    public class UnitOfWork : IUnitOfWork 
    {
        private readonly SportshopdbContext context;
        public UnitOfWork()
        {
            context = new();
        }
        public ICategoryRepository CategoryRepository => new CategoryRepository(context);
        public IManufacturerRepository ManufacturerRepository => new ManufacturerRepository(context);
        public ISpecificationRepository SpecificationRepository => new SpecificationRepository(context);
        public IProductRepository ProductRepository => new ProductRepository(context);

    }
}
