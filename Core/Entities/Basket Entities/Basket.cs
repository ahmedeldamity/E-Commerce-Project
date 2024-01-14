using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Basket_Entities
{
    public class Basket
    {
        public string Id { get; set; }
        public List<BasketItem> Items { get; set; }
        public Basket(string id)
        {
            Id = id;
            Items = new List<BasketItem>();
        }
    }
}