using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mud.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/parties")]
public class PartyController : ControllerBase
{
    public PartyController()
    {
        
    }
    
    
    // GET: /api/parties
    
    [HttpGet]
    public IActionResult GetParties()
    {
        return Ok();
    }
    
    
    // POST: /api/parties

    [HttpPost]
    public IActionResult AddParty()
    {
        return Ok();
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