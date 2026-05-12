namespace OrderManagementAPI.Domain.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<OrderItem> Items { get; set; } = [];

        public Order() { }

        public Order(List<OrderItem> items) 
        {
            CreatedDate = DateTime.UtcNow;
            Items = items;
        }
    }
}
