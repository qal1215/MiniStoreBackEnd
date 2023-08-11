using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class Product
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Unit { get; set; }

        public uint Stock { get; set; }

        public Category Category { get; set; } = null!;
    }

    public record CreateProduct
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Unit { get; set; }

        public uint Stock { get; set; }
    }

    public record ViewProduct
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Unit { get; set; }

        public uint Stock { get; set; }
    }
}
