namespace Core.Entities.Order_Entities
{
    public class OrderItem: BaseEntity
    {
        public OrderItem()
        {

        }
        public OrderItem(ProductOrderItem product, decimal price, int quantity)
        {
            Product = product;
            Price = price;
            Quantity = quantity;
        }

        public ProductOrderItem Product { get; set; } // this is a navigation property
                                                      // so EF will mapped it to database
                                                      // but we don't need that
                                                      // we need take his properties and mapped it in OrderItem table
                                                      // so will make configration for that :)
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
