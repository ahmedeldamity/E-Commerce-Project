namespace Core.Entities.Order_Entities
{
    public class ProductOrderItem
    {
        public ProductOrderItem()
        {

        }
        public ProductOrderItem(int productId, string productName, string pictureUrl)
        {
            ProductId = productId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}