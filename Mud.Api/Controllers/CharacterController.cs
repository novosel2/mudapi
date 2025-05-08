using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mud.Core.Dto.Character;
using Mud.Core.IServices;

namespace Mud.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/characters")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }


    // GET: /api/characters
    [HttpGet]
    public async Task<IActionResult> GetCharacters()
    {
        List<CharacterResponse> characters = await _characterService.GetAllAsync();
        
        return Ok(characters);
    }
    
    
    // GET: /api/characters/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCharacter(Guid id)
    {
        CharacterResponse character = await _characterService.GetByIdAsync(id);
        
        return Ok(character);
    }
    
    
    // POST: /api/characters
    
    [HttpPost]
    public async Task<IActionResult> AddCharacter(CharacterAddRequest characterAddRequest)
    {
        CharacterResponse character = await _characterService.AddAsync(characterAddRequest);
        
        return Ok(character);
    }
    
    
    // PUT: /api/characters

    [HttpPut]
    public async Task<IActionResult> UpdateCharacter(CharacterUpdateRequest characterUpdateRequest)
    {
        CharacterResponse character = await _characterService.UpdateAsync(characterUpdateRequest);
        
        return Ok(character);
    }
    
    
    // DELETE: /api/characters
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCharacter()
    {
        await _characterService.DeleteAsync();
        
        return Ok();
    }
}