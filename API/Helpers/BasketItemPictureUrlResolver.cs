using API.Dtos;
using AutoMapper;
using Core.Entities.Basket_Entities;

namespace API.Helpers
{
    public class BasketItemPictureUrlResolver : IValueResolver<BasketItem, BasketItemToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public BasketItemPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(BasketItem source, BasketItemToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
