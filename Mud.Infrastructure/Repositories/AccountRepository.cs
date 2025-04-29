using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Mud.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;

        public AccountRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Account?> GetByUsernameAsync(string username)
        {
            return await _db.Accounts.SingleOrDefaultAsync(x => x.Username == username);
        }
        
        public async Task<Account> AddAsync(Account account)
        {
            var accEntry = await _db.Accounts.AddAsync(account);
            return accEntry.Entity;
        }

        public async Task<bool> UsernameExistsAsync(string username)
        {
            return await _db.Accounts.AnyAsync(x => x.Username == username);
        }

        public async Task<bool> IsSavedAsync()
        {
            int saved = await _db.SaveChangesAsync();
            return saved > 0;
        }
    }
}
