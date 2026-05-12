using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Application.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order order);
    }
}
