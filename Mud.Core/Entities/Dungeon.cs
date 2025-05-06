using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Entities;

public class Dungeon
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public int SuggestedLevel { get; set; }
    
    [Required]
    public int SuggestedPartySize { get; set; }
    
    [Required]
    public double Playtime { get; set; }
    
    public List<Room> Rooms { get; set; } = [];
}