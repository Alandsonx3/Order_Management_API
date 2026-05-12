using Mapster;
using OrderManagementAPI.Application.DTOs.Request.Order;
using OrderManagementAPI.Application.DTOs.Response.Order;
using OrderManagementAPI.Application.Interfaces.Repositories;
using OrderManagementAPI.Application.Interfaces.Services;
using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public async Task<List<OrderResponseDto>> GetOrdersAsync()
        {
            var result = await _orderRepository.GetOrdersAsync();
            return result.Adapt<List<OrderResponseDto>>();
        }

        public async Task<OrderResponseDto?> GetOrderByIdAsync(int id)
        {
            var result = await _orderRepository.GetOrderByIdAsync(id);
            return result.Adapt<OrderResponseDto>();
        }

        public async Task<OrderResponseDto?> CreateOrderAsync(CreateOrderRequestDto request)
        {
            if (request.Items is null || !request.Items.Any())
                throw new Exception("Order must contain at least one item");

           

            var items = new List<OrderItem>();
            var productIds = request.Items.Select(x => x.ProductId).ToList();
            var products = await _productRepository.GetProductsByIdsAsync(productIds);
            var productsDictionary = products.ToDictionary(p => p.Id);

            foreach(var itemRequest in request.Items)
            {
                productsDictionary.TryGetValue(itemRequest.ProductId, out var productExist);

                if (productExist == null) throw new Exception($"Product {itemRequest.ProductId} not found");

                items.Add(new OrderItem(itemRequest.ProductId, itemRequest.Quantify, productExist.Price));
            }

            Order order = new Order(items);

            await _orderRepository.CreateOrderAsync(order);
            return order.Adapt<OrderResponseDto>();
        }
    }
}
