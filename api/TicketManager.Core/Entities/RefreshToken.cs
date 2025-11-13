using System.ComponentModel.DataAnnotations;

namespace TicketManager.Core.Entities;

public class RefreshToken : BaseEntity
{
    [Required]
    public string Token { get; set; } = string.Empty;

    [Required]
    public DateTime Expires { get; set; }

    public bool IsRevoked { get; set; } = false;

    public bool IsExpired => DateTime.UtcNow >= Expires;

    public string? CreatedByIp { get; set; }
    public string? ReplacedByToken { get; set; }

    // Foreign key
    public int UserId { get; set; }

    // Relation
    public User User { get; set; } = null!;
}