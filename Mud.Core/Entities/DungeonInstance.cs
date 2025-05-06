using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Entities;

public class DungeonInstance
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Guid PartyId { get; set; }
    
    [Required]
    public Guid DungeonId { get; set; }
    
    [Required]
    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    
    public Party? Party { get; set; }
    public Dungeon? Dungeon { get; set; }
}