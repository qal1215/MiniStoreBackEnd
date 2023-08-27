namespace MiniStore.ViewModels
{
    public class ViewOrder
    {
        public string OrderId { get; set; } = null!;

        public string? CustomerName { get; set; }

        public DateTime CreateDate { get; set; }

        public uint TotalItems { get; set; }

        public decimal TotalAmount { get; set; }

        public string? SalerId { get; set; }

        public string? Saler { get; set; }

        public IEnumerable<ViewOrderDetail> OrderDetails { get; set; } = null!;
    }

    public class CreateOrder
    {
        public string? CustomerName { get; set; }

        public string SalerId { get; set; } = null!;

        public decimal TotalAmount { get; set; }

        public uint TotalItems { get; set; }

        public decimal Cash { get; set; }

        public required List<ViewOrderDetail> OrderDetails { get; set; }
    }

    public class ViewOrderDetail
    {
        public string ProductId { get; set; } = null!;

        public string ProductName { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public uint Quantity { get; set; }

        public decimal Amount { get; set; }
    }
}
