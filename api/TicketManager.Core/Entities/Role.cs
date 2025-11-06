using System.ComponentModel.DataAnnotations;

namespace TicketManager.Core.Entities;

public class Role
{
    public int Id { get; set; }

    [Required, MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    // Relations
    public ICollection<User> Users { get; set; } = new List<User>();
}
