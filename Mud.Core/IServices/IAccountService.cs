using Mud.Core.Dto.Account;

namespace Mud.Core.IServices
{
    public interface IAccountService
    {
        /// <summary>
        /// Registers a new account asynchronously.
        /// </summary>
        /// <param name="registerDto">Account information</param>
        /// <returns>Account information and token</returns>
        public Task<AccountResponse> RegisterAsync(RegisterDto registerDto);
        
        /// <summary>
        /// Tries to log you in with sent information
        /// </summary>
        /// <param name="loginDto">Account information</param>
        /// <returns>Account information and token</returns>
        public Task<AccountResponse> LoginAsync(LoginDto loginDto);
    }
}
