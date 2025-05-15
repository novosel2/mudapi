using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mud.Core.IServices;
using System.Threading.Tasks;

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
    
    
    // DELETE: /api/parties/{id}
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteParty(Guid id)
    {
        await _partyService.DeletePartyAsync(id);

        return Ok();
    }
    
    
    // POST: /api/parties/join-party/{id}

    [HttpPost("join-party/{id:guid}")]
    public async Task<IActionResult> JoinPartyAsync(Guid id)
    {
        await _partyService.JoinPartyAsync(id);

        return Ok("Joined successfully.");
    }
    
    
    // POST: /api/parties/leave-party/{id}
    [HttpPost("leave-party")]
    public IActionResult LeaveParty()
    {
        return Ok();
    }
}