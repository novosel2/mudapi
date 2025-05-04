using Mud.Core.Dto.Character;
using Mud.Core.Entities;

namespace Mud.Core.IServices;

public interface ICharacterService
{
    /// <summary>
    /// Gets all characters from the database
    /// </summary>
    /// <returns>List of characters</returns>
    public Task<List<CharacterResponse>> GetAllAsync();
    
    /// <summary>
    /// Gets a character by id.
    /// </summary>
    /// <param name="id">ID of character</param>
    /// <returns>Character response</returns>
    public Task<CharacterResponse> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Adds a character to the database
    /// </summary>
    /// <param name="character">Character object to add</param>
    /// <returns>Added character object</returns>
    public Task<CharacterResponse> AddAsync(CharacterAddRequest character);
    
    /// <summary>
    /// Updates a character in the database.
    /// </summary>
    /// <param name="character">Character with updated information</param>
    /// <returns>Character response with updated information</returns>
    public Task<CharacterResponse> UpdateAsync(CharacterUpdateRequest character);
}