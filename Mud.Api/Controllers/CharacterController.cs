using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mud.Core.Dto.Character;
using Mud.Core.IServices;

namespace Mud.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/character")]
public class CharacterController : ControllerBase
{
    private readonly ICharacterService _characterService;

    public CharacterController(ICharacterService characterService)
    {
        _characterService = characterService;
    }


    // GET: /api/character
    [HttpGet]
    public async Task<IActionResult> GetCharacters()
    {
        var characters = await _characterService.GetAllAsync();
        
        return Ok(characters);
    }
    
    
    // GET: /api/character/{id}
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCharacter(Guid id)
    {
        var character = await _characterService.GetByIdAsync(id);
        
        return Ok(character);
    }
    
    
    // POST: /api/character
    
    [HttpPost]
    public async Task<IActionResult> AddCharacter(CharacterAddRequest characterAddRequest)
    {
        var character = await _characterService.AddAsync(characterAddRequest);
        
        return Ok(character);
    }
    
    
    // PUT: /api/character

    [HttpPut]
    public async Task<IActionResult> UpdateCharacter(CharacterUpdateRequest characterUpdateRequest)
    {
        var character = await _characterService.UpdateAsync(characterUpdateRequest);
        
        return Ok(character);
    }
}