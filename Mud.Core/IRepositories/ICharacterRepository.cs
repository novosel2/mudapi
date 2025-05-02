using Mud.Core.Entities;

namespace Mud.Core.IRepositories;

public interface ICharacterRepository
{
    /// <summary>
    /// Gets all characters from the database.
    /// </summary>
    /// <returns>List of characters</returns>
    public Task<List<Character>> GetAllAsync();
    
    public Task<Character> AddAsync(Character character);
}