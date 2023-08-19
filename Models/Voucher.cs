namespace MiniStore.Models
{
    public class Voucher
    {
        public int Id { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExpectedEndTime { get; set; }
        public DateTime? ActualEndTime { get; set; }
        public string Status { get; set; }
        public int RemainingProducts { get; set; }
        public string ProductId { get; set; } // Foreign Key
        public Product Product { get; set; }
    }
    public class VoucherCreate
    {
        public decimal DiscountAmount { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime ExpectedEndTime { get; set; }
        public DateTime? ActualEndTime { get; set; }
        public string Status { get; set; }
        public int RemainingProducts { get; set; }
        public string ProductId { get; set; }
    }
}
