using Mud.Core.Entities;

namespace Mud.Core.IRepositories;

public interface ICharacterRepository
{
    public Task<Character> AddAsync(Character character);
}