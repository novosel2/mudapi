using Mud.Core.Entities;

namespace Mud.Core.IRepositories;

public interface IPartyRepository
{
    /// <summary>
    /// Gets all parties from the database.
    /// </summary>
    /// <returns>List of parties</returns>
    public Task<List<Party>> GetAllAsync();

    /// <summary>
    /// Gets all parties from the database that are available for joining.
    /// </summary>
    /// <returns>List of available parties</returns>
    public Task<List<Party>> GetAllAvailableAsync();

    public Task<Party?> GetByIdAsync(Guid partyId);

    /// <summary>
    /// Creates a new party in the database.
    /// </summary>
    /// <param name="party">Party to be created</param>
    /// <returns>Created party</returns>
    public Task<Party> CreatePartyAsync(Party party);
    
    /// <summary>
    /// Gets a party by leader id.
    /// </summary>
    /// <param name="leaderId">ID of leader member</param>
    /// <returns>Party object with specified leader id</returns>
    public Task<Party?> GetByLeaderIdAsync(Guid leaderId);

    /// <summary>
    /// Gets a party by party member id.
    /// </summary>
    /// <param name="memberId">ID of member</param>
    /// <returns>Party object with specified member</returns>
    public Task<Party?> GetByPartyMemberIdAsync(Guid memberId);

    /// <summary>
    /// Adds a party member to the party.
    /// </summary>
    public Task JoinPartyAsync(PartyMember partyMember);

    /// <summary>
    /// Deletes a party from the database.
    /// </summary>
    /// <param name="party">Party to delete</param>
    /// <returns>Deleted object</returns>
    public Party DeleteParty(Party party);
    
    /// <summary>
    /// Checks if any changes are saved to the database. Returns true if there are changes saved, false otherwise.
    /// </summary>
    /// <returns>True if changes are saved to a database, otherwise false</returns>
    public Task<bool> IsSavedAsync();
}