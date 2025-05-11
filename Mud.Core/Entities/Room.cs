using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Entities;

public class Room
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public int PosX { get; set; }
    [Required]
    public int PosY { get; set; }
}