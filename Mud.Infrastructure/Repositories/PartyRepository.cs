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
            .ToListAsync();
    }

    // Gets all parties that are available for joining
    public async Task<List<Party>> GetAllAvailableAsync()
    {
        return await _db.Parties
            .Where(p => p.Members.Count < 4)
            .Include(p => p.Members)
            .ThenInclude(m => m.Character)
            .ToListAsync();;
    }

    // Creates a party in the database
    public async Task<Party> CreatePartyAsync(Party party)
    {
        var partyEntry = await _db.Parties.AddAsync(party);
        
        return partyEntry.Entity;
    }
}