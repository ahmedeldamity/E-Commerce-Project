using Core.Entities;
using Core.Entities.Order_Entities;
using Core.Interfaces.Repositories;
using Core.Interfaces.Services;
using Core.Specifications.Order_Specifications;

namespace Service
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;
        private readonly IPaymentService _paymentService;

        public OrderService(IUnitOfWork unitOfWork, IBasketRepository basketRepository, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _basketRepository = basketRepository;
            _paymentService = paymentService;
        }
        public async Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, OrderAddress shippingAddress)
        {
            // 1. Get basket from basket repository
            var basket = await _basketRepository.GetBasketAsync(basketId);

            // 2. Get Items at Basket from Product repository
            var orderitems = new List<OrderItem>();

            if (basket?.Items?.Count > 0)
            {
                foreach (var item in basket.Items)
                {
                    var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);

                    var productItemOrdered = new ProductOrderItem(item.Id, product.Name, product.PictureUrl);

                    var orderItem = new OrderItem(productItemOrdered, product.Price, item.Quantity);

                    orderitems.Add(orderItem);
                }
            }

            // 3. Calculate SubTotal
            var subTotal = orderitems.Sum(orderItem => orderItem.Price * orderItem.Quantity);

            // 4. Get Delivery Method
            var deliveryMethod = await _unitOfWork.Repository<OrderDeliveryMethod>().GetByIdAsync(basket.DeliveryMethodId);

            // Additional Step: check if order has Payment Intent will remove it
            var orderRepository = _unitOfWork.Repository<Order>();

            var orderSpec = new OrderWithPaymentIntentSpecifications(basket.PaymentIntentId);

            var existingOrder = await orderRepository.GetByIdWithSpecAsync(orderSpec);

            if (existingOrder != null)
            {
                orderRepository.Delete(existingOrder);

                // If order has old payment and then client update basket and don't create new payment then
                // client will pay on old payment intent
                // so I will create new payment from here for update payment so amount will updated
                await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            }

            // 5. Create New Order
            var order = new Order(buyerEmail, shippingAddress, deliveryMethod, orderitems, subTotal, basket.PaymentIntentId);

            await orderRepository.AddAsync(order);

            // 6. SaveChanges()
            var result = await _unitOfWork.CompleteAsync();

            if (result <= 0)
                return null;

            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var ordersRepo = _unitOfWork.Repository<Order>();

            var spec = new OrderSpecifications(buyerEmail);

            var orders = await ordersRepo.GetAllWithSpecAsync(spec);

            return orders;
        }

        public async Task<Order?> GetSpecificOrderForUserAsync(int orderId, string buyerEmail)
        {
            var ordersRepo = _unitOfWork.Repository<Order>();

            var spec = new OrderSpecifications(buyerEmail, orderId);

            var order = await ordersRepo.GetByIdWithSpecAsync(spec);

            return order;
        }

        public async Task<IReadOnlyList<OrderDeliveryMethod>> GetAllDeliveryMethodsAsync()
        {
            var deliveryMethodsRepo = _unitOfWork.Repository<OrderDeliveryMethod>();

            var deliveryMethods = await deliveryMethodsRepo.GetAllAsync();

            return deliveryMethods;
        }
    }
}