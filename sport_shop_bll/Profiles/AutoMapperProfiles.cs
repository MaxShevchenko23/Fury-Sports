using AutoMapper;
using sport_shop_bll.Models.Filter;
using sport_shop_bll.Models.GET;
using sport_shop_bll.Models.POST;
using sport_shop_bll.Models.UPDATE;
using sport_shop_dal.Entities;


namespace sport_shop_bll.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<Category, CategoryGet>().ReverseMap();
            CreateMap<Category, CategoryPost>().ReverseMap();
            CreateMap<Category, CategoryUpdate>().ReverseMap();
            CreateMap<Category, CategoryForCatalogueGet>().ReverseMap();

            CreateMap<Manufacturer, ManufacturerGet>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerPost>().ReverseMap();
            CreateMap<Manufacturer, ManufacturerUpdate>().ReverseMap();

            CreateMap<Product, ProductShortGet>().ReverseMap();
            CreateMap<Product, ProductFullGet>().ReverseMap();
            CreateMap<Product, ProductPost>().ReverseMap();
            CreateMap<Product, ProductUpdate>().ReverseMap();

            CreateMap<Specification, SpecificationGet>().ReverseMap();
            CreateMap<Specification, SpecificationPost>().ReverseMap();
            CreateMap<Specification, SpecificationUpdate>().ReverseMap();
            CreateMap<Specification, SpecificationFilter>().ReverseMap();

            CreateMap<Review, ReviewGet>().ReverseMap();
        }
    }
}
