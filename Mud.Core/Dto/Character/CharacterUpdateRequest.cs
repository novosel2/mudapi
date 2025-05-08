using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Dto.Character;

public class CharacterUpdateRequest
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name can only contain letters.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be at least 3 character long and less than 20 characters")]
    public string Name { get; set; } = string.Empty;

    public Entities.Character ToCharacter(Entities.Character character)
    {
        return new Entities.Character()
        {
            Id = Id,
            Name = Name,
            ClassId = character.ClassId,
            AccountUsername = character.AccountUsername,
            Level = character.Level,
            Experience = character.Experience,
            Health = character.Health,
        };
    }
}