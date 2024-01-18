using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Entities.Basket_Entities;
using Core.Entities.Identity;
using Core.Entities.Order_Entities;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        //private readonly IConfiguration _configuration;
        public MappingProfiles(/*IConfiguration configuration*/)
        {
            //_configuration = configuration;

            CreateMap<Product, ProductToReturnDto>()
                .ForMember(F => F.Brand, C => C.MapFrom(S => S.Brand.Name))
                .ForMember(F => F.Category, C => C.MapFrom(S => S.Category.Name))
                // -- We wanted to bring configuration to bring "ApiBaseUrl From appsetting.json 
                // -- but this isn't work because when we register automapper in program class 
                // -- it create this class with parameter less constractor 
                // -- so it will chain on the parameter less constractor and didn't see this constractor
                // -- so i commented the below line and configuration
                //.ForMember(d => d.PictureUrl, o => o.MapFrom(s => $"{_configuration["ApiBaseUrl"]}/{s.PictureUrl}"))
                // -- the solution of this issue is: instead of using MapFrom I use MapFrom<"class inherit from IValueResolver<sourse, destination, member>">
                .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());

            CreateMap<BasketDto, Basket>();

            CreateMap<BasketItemDto, BasketItem>();

            CreateMap<Basket, BasketToReturnDto>();

            CreateMap<BasketItem, BasketItemToReturnDto>()
           .ForMember(d => d.PictureUrl, o => o.MapFrom<BasketItemPictureUrlResolver>());

            CreateMap<Address, OrderAddressDto>();

            CreateMap<OrderAddressDto, Address>();

            CreateMap<OrderAddressDto, OrderAddress>();

            CreateMap<Order, OrderToReturnDto>() 
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.Name))
                .ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(s => s.DeliveryMethod.Cost));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.Product.ProductId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.Product.PictureUrl))
                .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderItemPictureUrlResolver>());

        }

        public IConfiguration Configuration { get; }
    }
}