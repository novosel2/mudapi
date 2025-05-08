using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mud.Core.IServices;

namespace Mud.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/parties")]
public class PartyController : ControllerBase
{
    private readonly IPartyService _partyService;
    
    public PartyController(IPartyService partyService)
    {
        _partyService = partyService;
    }
    
    
    // GET: /api/parties
    
    [HttpGet]
    public async Task<IActionResult> GetParties()
    {
        var parties = await _partyService.GetAllAsync();
        
        return Ok(parties);
    }
    
    
    // GET: /api/parties/available-parties

    [HttpGet("available-parties")]
    public async Task<IActionResult> GetAvailableParties()
    {
        var parties = await _partyService.GetAllAvailableAsync();

        return Ok(parties);
    }
    
    
    // POST: /api/parties

    [HttpPost]
    public async Task<IActionResult> AddParty()
    {
        var party = await _partyService.CreatePartyAsync();
        
        return Ok(party);
    }
    
    
    // DELETE: /api/parties
    
    [HttpDelete]
    public IActionResult DeleteParty()
    {
        return Ok();
    }
    
    
    // POST: /api/parties/join-party/{id}

    [HttpPost("join-party/{id:guid}")]
    public IActionResult JoinParty(Guid id)
    {
        return Ok();
    }
    
    
    // POST: /api/parties/leave-party/{id}
    [HttpPost("leave-party")]
    public IActionResult LeaveParty()
    {
        return Ok();
    }
}