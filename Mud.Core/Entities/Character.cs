namespace Mud.Core.Entities;

public class Character
{
    public Guid Id { get; set; }
    
    public string AccountUsername { get; set; } = string.Empty;
    
    public string Name { get; set; } = string.Empty;

    public int Level { get; set; }
    
    public int Experience { get; set; }
    
    public int Health { get; set; }
    
    public Guid ClassId { get; set; }
    public Class Class { get; set; } = null!;
    
    public Guid? EquippedItemId { get; set; }
    public Item? EquippedItem { get; set; }
    
    public Guid AccountId { get; set; }
}