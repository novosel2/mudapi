using Mud.Core.Entities;

namespace Mud.Core.IRepositories;

public interface ICharacterRepository
{
    /// <summary>
    /// Gets all characters from the database.
    /// </summary>
    /// <returns>List of characters</returns>
    public Task<List<Character>> GetAllAsync();
    
    /// <summary>
    /// Gets a character by id.
    /// </summary>
    /// <param name="id">ID of character</param>
    /// <returns>Character if found, otherwise null</returns>
    public Task<Character?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Adds a character to the database.
    /// </summary>
    /// <param name="character">Character object to add</param>
    /// <returns>Saved character</returns>
    public Task<Character> AddAsync(Character character);
    
    /// <summary>
    /// Updates a character in the database.
    /// </summary>
    /// <param name="existingCharacter">Existing character in the database</param>
    /// <param name="updatedCharacter">Character with updated information</param>
    /// <returns>Updated character</returns>
    public Task<Character> UpdateAsync(Character existingCharacter, Character updatedCharacter);

    /// <summary>
    /// Checks if an account has a character.
    /// </summary>
    /// <param name="accountId">ID of an account</param>
    /// <returns>True if exists, otherwise false</returns>
    public Task<bool> AccountCharacterExistsAsync(Guid accountId);
    
    /// <summary>
    /// Checks if any changes are saved to the database. Returns true if there are changes saved, false otherwise.
    /// </summary>
    /// <returns>True if changes are saved to a database, otherwise false</returns>
    public Task<bool> IsSavedAsync();
}