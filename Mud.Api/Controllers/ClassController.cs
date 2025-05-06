using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Mud.Core.IServices;

namespace Mud.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/classes")]
public class ClassController : ControllerBase
{
    private readonly IClassService _classService;
    
    public ClassController(IClassService classService)
    {
        _classService = classService;
    }
    
    
    // GET: /api/classes
    [HttpGet]
    public async Task<IActionResult> GetClasses()
    {
        var classes = await _classService.GetAllAsync();
        
        return Ok(classes);
    }
}