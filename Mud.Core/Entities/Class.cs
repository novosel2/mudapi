namespace Mud.Core.Entities;

public class Class
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int Intelligence { get; set; }
    
    public int Strength { get; set; }
    
    public int Dexterity { get; set; }
    
    public int Stamina { get; set; }
}