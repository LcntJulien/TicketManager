using System.ComponentModel.DataAnnotations;

namespace TicketManager.Core.Entities;

public class User
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Username { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    // Relations
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    // Helper
    public bool HasRole(string roleName) => Roles.Any(r => r.Name.Equals(roleName, StringComparison.OrdinalIgnoreCase));
}