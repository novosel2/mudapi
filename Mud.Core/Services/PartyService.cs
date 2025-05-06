using Mud.Core.Dto.Party;
using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Core.IServices;

namespace Mud.Core.Services;

public class PartyService : IPartyService
{
    private readonly IPartyRepository _partyRepository;
    
    public PartyService(IPartyRepository partyRepository)
    {
        _partyRepository = partyRepository;
    }
    
    // Gets all parties from the database
    public async Task<List<PartyResponse>> GetAllAsync()
    {
        List<Party> parties = await _partyRepository.GetAllAsync();
        List<PartyResponse> partyResponses = parties.Select(p => p.ToResponse()).ToList();
        
        return partyResponses;
    }

    // Gets all parties that are available for joining
    public Task<PartyResponse> GetAllAvailableAsync()
    {
        throw new NotImplementedException();
    }

    // Creates a party in the database
    public Task<PartyResponse> CreatePartyAsync()
    {
        throw new NotImplementedException();
    }
}