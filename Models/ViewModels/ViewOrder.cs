namespace MiniStore.Models.ViewModels
{
    public class Status
    {
        public int StatusId { get; set; }

        public string Title { get; set; } = null!;
    }

    public record ViewOrder
    {
        public string OrderId { get; set; } = null!;

        public string? CustomerName { get; set; }

        public DateTime CreateDate { get; set; }

        public decimal? Amount { get; set; }

        public int TotalItems { get; set; }

        public double TotalAmount { get; set; }

        public string? SalerId { get; set; }

        public double DiscountPrice { get; set; }

        public string? Saler { get; set; }

        public int StatusId { get; set; }

        public Status Status { get; set; } = null!;

        public IEnumerable<OrderDetail> OrderDetails { get; set; } = null!;
    }

    public record CreateOrder
    {

    }
}
