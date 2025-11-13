using System.ComponentModel.DataAnnotations;

namespace TicketManager.Core.Entities;

public class User : BaseEntity
{
    [Required, MaxLength(100)]
    public string Username { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    [Required]
    public bool IsActive { get; set; } = true;

    public DateTime LastLogin { get; set; }

    // Relations
    public ICollection<Role> Roles { get; set; } = new List<Role>();
    public ICollection<Ticket> CreatedTickets { get; set; } = new List<Ticket>();
    public ICollection<Ticket> AssignedTickets { get; set; } = new List<Ticket>();
    public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();

    // Helper
    public bool HasRole(params string[] roleNames)
    {
        if (Roles == null || Roles.Count == 0) return false;

        return Roles.Any(r => roleNames.Any(name =>
            r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)));
    }
}