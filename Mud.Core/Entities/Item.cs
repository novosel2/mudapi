using Mud.Core.Enums;

namespace Mud.Core.Entities;

public class Item
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public int Value { get; set; }
    
    public ItemType Type { get; set; }
}