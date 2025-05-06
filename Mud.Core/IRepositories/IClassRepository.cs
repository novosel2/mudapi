using Mud.Core.Entities;

namespace Mud.Core.IRepositories;

public interface IClassRepository
{
    /// <summary>
    /// Gets all classes from the database.
    /// </summary>
    /// <returns>List of classes</returns>
    public Task<List<Class>> GetAllAsync();
    
    /// <summary>
    /// Gets a class by id.
    /// </summary>
    /// <param name="id">ID of class</param>
    /// <returns>Class if it exists, otherwise null</returns>
    public Task<Class?> GetByIdAsync(Guid id);
    
    /// <summary>
    /// Checks if a class exists.
    /// </summary>
    /// <param name="id">ID of class</param>
    /// <returns>True if it exists, otherwise false</returns>
    public Task<bool> ClassExistsAsync(Guid id);
}