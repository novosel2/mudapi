namespace Mud.Core.Dto.Character;

public class CharacterResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string AccountUsername { get; set; } = string.Empty;
    public int Level { get; set; }
    public int Experience { get; set; }
    public int Health { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public string EquippedItemName { get; set; } = string.Empty;
}

public static class CharacterExtension
{
    public static CharacterResponse ToResponse(this Entities.Character character, string? className = null)
    {
        return new CharacterResponse
        {
            Id = character.Id,
            Name = character.Name,
            AccountUsername = character.AccountUsername,
            Level = character.Level,
            Experience = character.Experience,
            Health = character.Health,
            ClassName = className ?? character.Class?.Name ?? "None",
            EquippedItemName = character.EquippedItem?.Name ?? "None"
        };
    }
}