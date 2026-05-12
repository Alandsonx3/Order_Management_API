using OrderManagementAPI.Application.DTOs.Request.Order;
using OrderManagementAPI.Application.DTOs.Response.Order;
using OrderManagementAPI.Domain.Entities;

namespace OrderManagementAPI.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<List<OrderResponseDto>> GetOrdersAsync();
        Task<OrderResponseDto?> GetOrderByIdAsync(int id);
        Task<OrderResponseDto?> CreateOrderAsync(CreateOrderRequestDto order);
    }
}
