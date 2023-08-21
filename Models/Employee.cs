using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class Employee
    {
        [Key]
        public string Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        [Url]
        public string? ImgUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; } = null!;
    }

    public class Position
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = null!;
    }

    public record ViewEmployee
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? ImgUrl { get; set; }

        public string Position { get; set; } = null!;

        public DateTime CreateDate { get; set; }
    }

    public record LoginRecord
    {
        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
    }

    public record RegisterRecord
    {
        public string Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        [Url]
        public string? ImgUrl { get; set; }

        public string RoleName { get; set; } = null!;
    }

    public record UpdateRecord
    {
        public string Id { get; set; } = null!;

        [EmailAddress]
        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        [Url]
        public string? ImgUrl { get; set; }

        public string? RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
