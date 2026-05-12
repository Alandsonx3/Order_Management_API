using OrderManagementAPI.Application.DTOs.Response.Order;

namespace OrderManagementAPI.Application.DTOs.Request.Order
{
    public class CreateOrderRequestDto
    {
        public List<OrderItemRequestDto> Items { get; set; } = [];
    }
}
