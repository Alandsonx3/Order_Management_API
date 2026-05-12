namespace OrderManagementAPI.Application.DTOs.Response.Order
{
    public class OrderItemResponseDto
    {  
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Quantify { get; set; }
        public decimal PriceActual { get; set; }
    }
}
