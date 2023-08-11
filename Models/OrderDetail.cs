namespace MiniStore.Models
{
    public class OrderDetail
    {
        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public string OrderId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
