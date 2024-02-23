namespace sport_shop_dal.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ISpecificationRepository SpecificationRepository { get; }
        IManufacturerRepository ManufacturerRepository { get; }
        ICategoryRepository CategoryRepository { get; }
    }
}