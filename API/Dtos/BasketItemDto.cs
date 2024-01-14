using Core.Entities.Basket_Entities;

namespace API.Dtos
{
    public class BasketItemDto
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }
    }
}