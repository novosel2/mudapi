using Mud.Core.Entities;

namespace Mud.Core.IRepositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Gets an account with specified username if exists
        /// </summary>
        /// <param name="username">Username of an account</param>
        /// <returns>Account with a specified username if exists</returns>
        public Task<Account?> GetByUsernameAsync(string username);
        
        /// <summary>
        /// Adds a new account asynchronously.
        /// </summary>
        /// <param name="account">Account information</param>
        /// <returns>Account information</returns>
        public Task<Account> AddAsync(Account account);

        /// <summary>
        /// Checks if the username already exists.
        /// </summary>
        /// <param name="username">Username to check</param>
        /// <returns>True if the username exists, otherwise false</returns>
        public Task<bool> UsernameExistsAsync(string username);

        /// <summary>
        /// Checks if any changes are saved to the database. Returns true if there are changes saved, false otherwise.
        /// </summary>
        /// <returns>True if changes are saved to a database, otherwise false</returns>
        public Task<bool> IsSavedAsync();
    }
}
