namespace ProductShop.App
{
    using AutoMapper;
    using ProductShop.App.Dto;
    using ProductShop.App.Dto.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
            CreateMap<CategoriesDto, Category>();
            CreateMap<Category, CategoriesDto>();
        }
    }
}
