namespace OrderManagementAPI.Application.DTOs.Response.Product
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantify { get; set; }
        public DateTime CreatedAt { get; private set; }
    }
}
