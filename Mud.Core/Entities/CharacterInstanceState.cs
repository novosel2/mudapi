using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Entities;

public class CharacterInstanceState
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Guid CharacterId { get; set; }
    
    [Required]
    public Guid InstanceId { get; set; }
    
    [Required]
    public Guid CurrentRoomId { get; set; }

    [Required] 
    public int PosX { get; set; } = 0;
    [Required] 
    public int PosY { get; set; } = 0;
    
    public Character? Character { get; set; }
    public DungeonInstance? Instance { get; set; }
    public Room? CurrentRoom { get; set; }
}