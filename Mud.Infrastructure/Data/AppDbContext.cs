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
        public DbSet<Character> Characters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Dungeon> Dungeons { get; set; }
        public DbSet<PartyMember> PartyMembers { get; set; }
        public DbSet<DungeonInstance> DungeonInstances { get; set; }
        public DbSet<CharacterInstanceState> CharacterInstanceStates { get; set; }
    }
}
