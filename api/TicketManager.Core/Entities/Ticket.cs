using System.ComponentModel.DataAnnotations;
using TicketManager.Core.Enums;

namespace TicketManager.Core.Entities;

public class Ticket : AuditableEntity
{
    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [Required, MaxLength(2000)]
    public string Description { get; set; } = string.Empty;

    public TicketPriority? Priority { get; set; } = TicketPriority.Medium;

    [Required]
    public TicketStatus Status { get; set; } = TicketStatus.Backlog;

    public DateTime? ClosedAt { get; set; }

    // Foreign key
    public int? CreatedById { get; set; }

    // Relations
    public User? CreatedBy { get; set; }
    public ICollection<User> AssignedUsers { get; set; } = new List<User>();
    public ICollection<Role> AssignedRoles { get; set; } = new List<Role>();
}