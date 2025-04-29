using System.ComponentModel.DataAnnotations;

namespace Mud.Core.Dto.Character;

public class CharacterAddRequest
{
    [Required]
    [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name can only contain letters.")]
    [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be at least 3 character long and less than 20 characters")]
    public string Name { get; set; } = string.Empty;

    [Required] 
    public Guid ClassId { get; set; }

    public Entities.Character ToCharacter(Guid accountId, string accountUsername)
    {
        return new Entities.Character()
        {
            Name = Name,
            ClassId = ClassId,
            AccountId = accountId,
            AccountUsername = accountUsername,
            Level = 1,
            Experience = 0,
            Health = 100
        };
    }
}