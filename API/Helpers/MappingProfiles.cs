using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                .ForMember(F => F.Brand, C => C.MapFrom(S => S.Brand.Name))
                .ForMember(F => F.Category, C => C.MapFrom(S => S.Category.Name));
        }
    }
}