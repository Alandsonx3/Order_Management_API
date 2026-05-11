namespace OrderManagementAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItem> Items { get; set; } = [];
    }
}
