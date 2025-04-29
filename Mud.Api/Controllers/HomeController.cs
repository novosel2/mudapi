using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mud.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/home")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok("Welcome to the Mud API!");
    }

    [HttpGet("error")]
    public IActionResult Error()
    {
        return Problem("An error occurred.");
    }
}