using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Entities;

public class Party
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public List<PartyMember> Members { get; set; } = [];
}