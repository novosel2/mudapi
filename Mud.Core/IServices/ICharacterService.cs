using Mud.Core.Dto.Character;
using Mud.Core.Entities;

namespace Mud.Core.IServices;

public interface ICharacterService
{
    /// <summary>
    /// Adds a character to the database
    /// </summary>
    /// <param name="character">Character object to add</param>
    /// <returns>Added character object</returns>
    public Task<CharacterResponse> AddAsync(CharacterAddRequest character);
    
    /// <summary>
    /// Checks if any changes are saved to the database
    /// </summary>
    /// <returns>True if changes are saved, otherwise false</returns>
    public Task<bool> IsSavedAsync();
}