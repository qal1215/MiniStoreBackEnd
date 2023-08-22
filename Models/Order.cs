using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniStore.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;

        public string? CustomerName { get; set; }

        public string? SalerId { get; set; }

        public uint TotalItems { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime CreateDate { get; set; }

        public double DiscountPrice { get; set; }

        public int StatusId { get; set; }

        public Employee? Saler { get; set; }

        public OrderStatus Status { get; set; } = null!;

        public List<OrderDetail> OrderDetails { get; set; } = null!;
    }

    public class OrderStatus
    {
        [Key]
        public int StatusId { get; set; }

        public string Title { get; set; } = null!;
    }
}
