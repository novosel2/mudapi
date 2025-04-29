using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Mud.Core.Services;

public class CurrentAccountService
{
    public Guid? CurrentAccountId { get; set; }
    
    public CurrentAccountService(IHttpContextAccessor httpContextAccessor)
    {
        CurrentAccountId = Guid.TryParse(httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var accountId) ? accountId : null;
    }
}