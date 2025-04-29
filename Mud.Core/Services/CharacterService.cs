using Mud.Core.Dto.Character;
using Mud.Core.Entities;
using Mud.Core.IServices;

namespace Mud.Core.Services;

public class CharacterService : ICharacterService
{
    public Task<CharacterResponse> AddAsync(CharacterAddRequest character)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> IsSavedAsync()
    {
        throw new NotImplementedException();
    }
}