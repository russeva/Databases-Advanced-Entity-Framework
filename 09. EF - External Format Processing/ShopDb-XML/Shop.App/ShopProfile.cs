namespace Shop.App
{
    using AutoMapper;
    using Shop.App.Dto.Import;
    using Shop.Models;

    public class ShopProfile : Profile
    {
        public ShopProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<ImportProductDto, Product>();
            CreateMap<Product, ImportProductDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<Category, CategoryDto>();
            

        }
    }
}
