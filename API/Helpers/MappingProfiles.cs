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
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(F => F.Brand, C => C.MapFrom(S => S.Brand.Name))
                .ForMember(F => F.Category, C => C.MapFrom(S => S.Category.Name));

            CreateMap<BasketDto, Basket>();

            CreateMap<BasketItemDto, BasketItem>();

            CreateMap<Address, OrderAddressDto>();

            CreateMap<OrderAddressDto, Address>();

            CreateMap<OrderAddressDto, OrderAddress>();

            CreateMap<Order, OrderToReturnDto>() 
                .ForMember(d => d.DeliveryMethod, o => o.MapFrom(s => s.DeliveryMethod.Name))
                .ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(s => s.DeliveryMethod.Cost));

            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.Product.ProductId))
                .ForMember(d => d.ProductName, o => o.MapFrom(s => s.Product.ProductName))
                .ForMember(d => d.PictureUrl, o => o.MapFrom(s => s.Product.PictureUrl));
        }
    }
}