namespace API.Dtos
{
    public class BasketToReturnDto
    {
        public string Id { get; set; }
        public List<BasketItemToReturnDto> Items { get; set; }
    }
}