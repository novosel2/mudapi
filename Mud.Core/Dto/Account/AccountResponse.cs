using Mud.Core.Entities;

namespace Mud.Core.Dto.Account;

public class AccountResponse
{
    public Guid Id { get; set; }
        
    public string Username { get; set; } = string.Empty;
        
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string Token { get; set; } = string.Empty;
}

public static class AccountExtension
{
    public static AccountResponse ToResponse(this Entities.Account account, string token)
    {
        return new AccountResponse
        {
            Id = account.Id,
            Username = account.Username,
            CreatedAt = account.CreatedAt,
            Token = token
        };
    }
}