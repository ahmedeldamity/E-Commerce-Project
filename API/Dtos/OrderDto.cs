using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class OrderDto
    {
        [Required]
        public string BasketId { get; set; }

        [Required]
        public int DeliveryMethodId { get; set; }

        [Required]
        public OrderAddressDto ShippingAddress { get; set; }
    }
}