namespace OrderManagementAPI.Application.DTOs
{
    public class ProductResponseDto
    {
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantify { get; set; }
    }
}
