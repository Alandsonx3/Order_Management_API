namespace OrderManagementAPI.Application.DTOs.Request
{
    public class UpdateProductRequestDto
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantify { get; set; }
    }
}