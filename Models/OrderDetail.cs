using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniStore.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public double UnitPrice { get; set; }

        public int Quantity { get; set; }

        public string OrderId { get; set; } = null!;

        public string ProductId { get; set; } = null!;

        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
