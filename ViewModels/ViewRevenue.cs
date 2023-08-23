namespace MiniStore.ViewModels
{
    public class ViewRevenue
    {
    }
    public class RevenueResponse
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
