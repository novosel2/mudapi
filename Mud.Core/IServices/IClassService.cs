using Mud.Core.Dto.Class;

namespace Mud.Core.IServices;

public interface IClassService
{
    /// <summary>
    /// Gets all classes from the database.
    /// </summary>
    /// <returns>List of class responses</returns>
    public Task<List<ClassResponse>> GetAllAsync();
}