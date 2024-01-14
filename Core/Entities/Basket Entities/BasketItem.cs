using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Basket_Entities
{
    public class BasketItem
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public string PictureUrl { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Price must be greater than zero!")]
        public decimal Price { get; set; }
       
        public string Category { get; set; }
        
        public string Brand { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least one item!")]
        public int Quantity { get; set; }
    }
}