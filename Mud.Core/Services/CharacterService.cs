using Mud.Core.Dto.Character;
using Mud.Core.Entities;
using Mud.Core.Exceptions;
using Mud.Core.IRepositories;
using Mud.Core.IServices;

namespace Mud.Core.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;
    private readonly IClassRepository _classRepository;
    private readonly Guid _accountId;
    private readonly string _username;
    
    public CharacterService(ICharacterRepository characterRepository, IClassRepository classRepository, CurrentAccountService currentAccountService)
    {
        _characterRepository = characterRepository;
        _classRepository = classRepository;
        _accountId = currentAccountService.CurrentAccountId ?? throw new UnauthorizedAccessException("Unauthorized access.");
        _username = currentAccountService.Username ?? throw new UnauthorizedAccessException("Unauthorized access.");
    }
    
    // Gets all characters from the database
    public async Task<List<CharacterResponse>> GetAllAsync()
    {
        List<Character> characters = await _characterRepository.GetAllAsync();
        List<CharacterResponse> response = characters.Select(x => x.ToResponse()).ToList();

        return response;
    }

    // Gets a character by id.
    public async Task<CharacterResponse> GetByIdAsync(Guid id)
    {
        Character character = await _characterRepository.GetByIdAsync(id)
            ?? throw new NotFoundException($"Character with id {id} not found.");

        return character.ToResponse();
    }

    // Adds a character to the database
    public async Task<CharacterResponse> AddAsync(CharacterAddRequest characterAddRequest)
    {
        Character character = characterAddRequest.ToCharacter(_accountId, _username);
     
        Class characterClass = await _classRepository.GetByIdAsync(character.ClassId)
            ?? throw new NotFoundException($"Class with id {character.ClassId} not found.");
        
        if (await _characterRepository.AccountCharacterExistsAsync(_accountId))
            throw new AlreadyExistsException("Account already has a character.");
        
        Character createdCharacter = await _characterRepository.AddAsync(character);

        if (!await _characterRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to save character to the database.");
        
        return createdCharacter.ToResponse(characterClass.Name);
    }

    // Deletes a character in the database
    public async Task DeleteAsync()
    {
        Character character = await _characterRepository.GetByIdAsync(_accountId)
            ?? throw new NotFoundException($"Character with id {_accountId} not found.");
        
        if (character.Id != _accountId)
            throw new ForbiddenException("Action not allowed.");
        
        await _characterRepository.DeleteAsync(character);
        
        if (! await _characterRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to delete character in the database.");
    }

    // Updates a character in the database.
    public async Task<CharacterResponse> UpdateAsync(CharacterUpdateRequest characterUpdateRequest)
    {
        Character existingCharacter = await _characterRepository.GetByIdAsync(characterUpdateRequest.Id)
            ?? throw new NotFoundException($"Character with id {characterUpdateRequest.Id} not found.");
        
        Character updatedCharacter = characterUpdateRequest.ToCharacter(existingCharacter);
        
        Character character = await _characterRepository.UpdateAsync(existingCharacter, updatedCharacter);
        
        if (! await _characterRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to save character to the database.");
        
        return character.ToResponse(existingCharacter.Class.Name);
    }
}