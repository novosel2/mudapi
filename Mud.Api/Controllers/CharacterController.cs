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


    // POST: /api/character
    
    [HttpPost]
    public async Task<IActionResult> AddCharacter(CharacterAddRequest character)
    {
        var characterResponse = await _characterService.AddAsync(character);
        
        return Ok(characterResponse);
    }
}