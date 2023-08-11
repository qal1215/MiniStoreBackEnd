using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniStore.Models
{
    public class Account
    {
        [Key]
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsActive { get; set; } = true;

        public string? ImgUrl { get; set; }

        public DateTime CreateDate { get; set; }

        public Role Role { get; set; } = null!;
    }

    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        public string Name { get; set; } = null!;
    }

    public record ViewAccount
    {
        public string Id { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public string Password { get; set; } = null!;

        public bool IsActive { get; set; }

        public string? ImgUrl { get; set; }

        public string Role { get; set; } = null!;

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

        public string RoleName { get; set; }
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

        public string RoleName { get; set; }

        public bool IsActive { get; set; }
    }
}
