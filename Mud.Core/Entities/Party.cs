using System.ComponentModel.DataAnnotations;
using Mud.Core.Entities;

namespace Mud.Core.Entities;

public class Party
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public virtual List<PartyMember> Members { get; set; } = [];
}