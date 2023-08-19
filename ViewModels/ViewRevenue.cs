using MiniStore.Models;

namespace MiniStore.ViewModels
{
    public class ViewRevenue
    {
    }
    public class RevenueResponse
    {
        public List<Order> OrderInRange { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
