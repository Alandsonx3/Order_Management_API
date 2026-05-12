namespace OrderManagementAPI.Application.DTOs.Response.Order
{
    public class OrderResponseDto
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItemResponseDto> Items { get; set; } = [];
    }
}