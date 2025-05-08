namespace Mud.Core.Dto.Class;

public class ClassResponse
{
    public Guid ClassId { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public int Intelligence { get; set; }
    
    public int Strength { get; set; }
    
    public int Dexterity { get; set; }
    
    public int Stamina { get; set; }
}

public static class ClassExtension
{
    public static ClassResponse ToResponse(this Entities.Class varClass)
    {
        return new ClassResponse
        {
            ClassId = varClass.Id,
            Name = varClass.Name,
            Intelligence = varClass.Intelligence,
            Strength = varClass.Strength,
            Dexterity = varClass.Dexterity,
            Stamina = varClass.Stamina
        };
    }
}