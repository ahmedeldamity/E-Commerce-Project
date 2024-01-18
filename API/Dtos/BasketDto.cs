using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketDto
    {
        public string Id { get; set; }

        public List<BasketItemDto> Items { get; set; }

        [Required]
        public int DeliveryMethodId { get; set; }
    }
}
