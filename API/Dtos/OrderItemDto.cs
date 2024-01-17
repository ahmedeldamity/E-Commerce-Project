namespace API.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; } // Id For Product As Arrange In List Of Items
        public int ProductId { get; set; }  // Id For Product In Database
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}