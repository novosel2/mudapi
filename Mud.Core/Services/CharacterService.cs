using Mud.Core.Dto.Character;
using Mud.Core.Entities;
using Mud.Core.Exceptions;
using Mud.Core.IRepositories;
using Mud.Core.IServices;

namespace Mud.Core.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly Guid _accountId;
    private readonly string _username;
    
    public CharacterService(ICharacterRepository characterRepository, CurrentAccountService currentAccountService)
    {
        _characterRepository = characterRepository;
        _accountId = currentAccountService.CurrentAccountId ?? throw new UnauthorizedAccessException("Unauthorized access.");
        _username = currentAccountService.Username ?? throw new UnauthorizedAccessException("Unauthorized access.");
    }
    
    // Gets all characters from the database
    public async Task<List<CharacterResponse>> GetAllAsync()
    {
        var characters = await _characterRepository.GetAllAsync();
        var response = characters.Select(x => x.ToResponse()).ToList();

        return response;
    }

    // Gets a character by id.
    public async Task<CharacterResponse> GetByIdAsync(Guid id)
    {
        var character = await _characterRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Character with id {id} not found.");

        return character.ToResponse();
    }

    // Adds a character to the database
    public async Task<CharacterResponse> AddAsync(CharacterAddRequest characterAddRequest)
    {
        var character = characterAddRequest.ToCharacter(_accountId, _username);
        
        var createdCharacter = await _characterRepository.AddAsync(character);

        if (!await _characterRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to save character to the database.");
        
        return createdCharacter.ToResponse();
    }

    // Updates a character in the database.
    public async Task<CharacterResponse> UpdateAsync(CharacterUpdateRequest characterUpdateRequest)
    {
        var existingCharacter = await _characterRepository.GetByIdAsync(characterUpdateRequest.Id)
            ?? throw new NotFoundException($"Character with id {characterUpdateRequest.Id} not found.");
        
        var updatedCharacter = characterUpdateRequest.ToCharacter(existingCharacter);
        
        var character = await _characterRepository.UpdateAsync(existingCharacter, updatedCharacter);
        
        if (! await _characterRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to save character to the database.");
        
        return character.ToResponse();
    }
}