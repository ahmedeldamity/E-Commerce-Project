namespace Core.Entities.Order_Entities
{
    public class OrderDeliveryMethod: BaseEntity
    {
        public OrderDeliveryMethod()
        {

        }
        public OrderDeliveryMethod(string name, string description, decimal cost, string deliveryTime)
        {
            Name = name;
            Description = description;
            Cost = cost;
            DeliveryTime = deliveryTime;
        }

        public string Name { get; set; } // the name of delivery way
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string DeliveryTime { get; set; } // the time delivery will take to bring the order
    }
}