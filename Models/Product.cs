using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniStore.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Unit { get; set; } = null!;

        public uint Stock { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }

    public record CreateProduct
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Unit { get; set; } = null!;

        public uint Stock { get; set; }
    }

    public record ViewProduct
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string Category { get; set; } = null!;

        public string Unit { get; set; } = null!;

        public uint Stock { get; set; }
    }
}
