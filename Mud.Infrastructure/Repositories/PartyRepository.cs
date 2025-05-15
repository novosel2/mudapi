using Microsoft.EntityFrameworkCore;
using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Infrastructure.Data;

namespace Mud.Infrastructure.Repositories;

public class PartyRepository : IPartyRepository
{
    private readonly AppDbContext _db;
    
    public PartyRepository(AppDbContext db)
    {
        _db = db;
    }
    
    // Gets all parties from the database
    public async Task<List<Party>> GetAllAsync()
    {
        return await _db.Parties
            .Include(p => p.Members)
            .ThenInclude(m => m.Character)
            .ThenInclude(c => c.Class)
            .ToListAsync();
    }

    // Gets all parties that are available for joining
    public async Task<List<Party>> GetAllAvailableAsync()
    {
        return await _db.Parties
            .Where(p => p.Members.Count < 4)
            .Include(p => p.Members)
            .ThenInclude(m => m.Character)
            .ToListAsync();
    }

    // Gets a party by id
    public async Task<Party?> GetByIdAsync(Guid partyId)
    {
        return await _db.Parties
            .Include(p => p.Members)
            .ThenInclude(m => m.Character)
            .ThenInclude(c => c.Class)
            .SingleOrDefaultAsync(p => p.Id == partyId);
    }

    // Creates a party in the database
    public async Task<Party> CreatePartyAsync(Party party)
    {
        var partyEntry = await _db.Parties.AddAsync(party);
        
        return partyEntry.Entity;
    }

    // Deletes a party from the database
    public Party DeleteParty(Party party)
    {
        var partyEntry = _db.Parties.Remove(party);

        return partyEntry.Entity;
    }

    // Gets a party by leader id
    public async Task<Party?> GetByLeaderIdAsync(Guid leaderId)
    {
        return await _db.Parties.SingleOrDefaultAsync(p => p.Members.Any(m => m.CharacterId == leaderId && m.IsLeader));
    }

    // Adds a party member to the party
    public async Task JoinPartyAsync(PartyMember partyMember)
    {
        await _db.PartyMembers.AddAsync(partyMember);
    }

    // Checks if any changes are saved to the database. Returns true if there are changes saved, false otherwise.
    public async Task<bool> IsSavedAsync()
    {
        int saved = await _db.SaveChangesAsync();
        
        return saved > 0;
    }
}