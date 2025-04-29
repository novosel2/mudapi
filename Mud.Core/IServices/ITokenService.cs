using Mud.Core.Entities;

namespace Mud.Core.IServices;

public interface ITokenService
{
    /// <summary>
    /// Generate a JWT for a specified account
    /// </summary>
    /// <param name="account">Account that needs a JWT</param>
    /// <returns>Json Web Token</returns>
    public string GenerateToken(Account account);
}