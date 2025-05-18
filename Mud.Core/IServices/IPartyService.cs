using Mud.Core.Dto.Party;

namespace Mud.Core.IServices;

public interface IPartyService
{
    /// <summary>
    /// Gets all parties from the database
    /// </summary>
    /// <returns>List of party responses</returns>
    public Task<List<PartyResponse>> GetAllAsync();
    
    /// <summary>
    /// Gets all parties available for joining
    /// </summary>
    /// <returns>List of available party responses</returns>
    public Task<List<PartyResponse>> GetAllAvailableAsync();

    /// <summary>
    /// Creates a new party
    /// </summary>
    /// <returns>Created party response</returns>
    public Task<PartyResponse> CreatePartyAsync();

    /// <summary>
    /// Joins a party
    /// </summary>
    /// <param name="partyId">Party id to join</param>
    public Task JoinPartyAsync(Guid partyId);

    /// <summary>
    /// Leaves the party
    /// </summary>
    public Task LeavePartyAsync();

    /// <summary>
    /// Delete party
    /// </summary>
    /// <param name="partyId">Party to delete</param>
    public Task DeletePartyAsync(Guid partyId);
}

