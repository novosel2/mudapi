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

    /// <summary>
    /// Creates a new party in the database.
    /// </summary>
    /// <param name="party">Party to be created</param>
    /// <returns>Created party</returns>
    public Task<Party> CreatePartyAsync(Party party);
}