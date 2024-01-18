using Core.Entities.Order_Entities;

namespace Core.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethodId, OrderAddress shippingAddress);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);
        Task<Order?> GetSpecificOrderForUserAsync(int orderId, string buyerEmail);
        Task<IReadOnlyList<OrderDeliveryMethod>> GetAllDeliveryMethodsAsync();
    }
}