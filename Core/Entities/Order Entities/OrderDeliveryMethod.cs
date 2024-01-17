namespace Core.Entities.Order_Entities
{
    public class OrderDeliveryMethod: BaseEntity
    {
        public OrderDeliveryMethod()
        {

        }
        public OrderDeliveryMethod(string name, string descriptions, decimal cost, string deliveryTime)
        {
            Name = name;
            Descriptions = descriptions;
            Cost = cost;
            DeliveryTime = deliveryTime;
        }

        public string Name { get; set; } // the name of delivery way
        public string Descriptions { get; set; }
        public decimal Cost { get; set; }
        public string DeliveryTime { get; set; } // the time delivery will take to bring the order
    }
}