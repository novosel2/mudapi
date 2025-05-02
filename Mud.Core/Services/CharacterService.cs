using Mud.Core.Dto.Character;
using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Core.IServices;

namespace Mud.Core.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    
    public CharacterService(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }
    
    public async Task<List<CharacterResponse>> GetAllAsync()
    {
        var characters = await _characterRepository.GetAllAsync();
        var response = characters.Select(x => x.ToResponse()).ToList();

        return response;
    }

    public Task<CharacterResponse> AddAsync(CharacterAddRequest character)
    {
        throw new NotImplementedException();
    }
    
    public Task<bool> IsSavedAsync()
    {
        throw new NotImplementedException();
    }
}