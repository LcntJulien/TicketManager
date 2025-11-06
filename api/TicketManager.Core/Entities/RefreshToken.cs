using System.ComponentModel.DataAnnotations;

namespace TicketManager.Core.Entities;

public class RefreshToken
{
    public int Id { get; set; }

    [Required]
    public string Token { get; set; } = string.Empty;

    [Required]
    public DateTime Expires { get; set; }

    public bool IsRevoked { get; set; } = false;

    public bool IsExpired => DateTime.UtcNow >= Expires;

    // Foreign key
    public int UserId { get; set; }
    public User User { get; set; } = null!;
}
