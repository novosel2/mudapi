using Microsoft.EntityFrameworkCore;
using Mud.Core.Entities;

namespace Mud.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<Account> Accounts { get; set; }
    }
}
