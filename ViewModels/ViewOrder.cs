using MiniStore.Models;

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

        public int StatusId { get; set; }

        public OrderStatus Status { get; set; } = null!;

        public IEnumerable<OrderDetail> OrderDetails { get; set; } = null!;
    }

    public class CreateOrder
    {
        public string? CustomerName { get; set; }

        public string SalerId { get; set; } = null!;

        public required List<ViewOrderDetail> OrderDetails { get; set; }
    }

    public class ViewOrderDetail
    {
        public string ProductId { get; set; } = null!;

        public decimal UnitPrice { get; set; }

        public uint Quantity { get; set; }
    }
}
