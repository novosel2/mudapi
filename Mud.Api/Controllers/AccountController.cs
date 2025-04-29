using Microsoft.AspNetCore.Mvc;
using Mud.Core.Dto.Account;
using Mud.Core.IServices;

namespace Mud.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
        AccountResponse accountResponse = await _accountService.RegisterAsync(registerDto);

        return Ok(accountResponse);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
        AccountResponse accountResponse = await _accountService.LoginAsync(loginDto);
            
        return Ok(accountResponse);
    }
}