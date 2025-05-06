using Microsoft.EntityFrameworkCore;
using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Infrastructure.Data;

namespace Mud.Infrastructure.Repositories;

public class ClassRepository : IClassRepository
{
    private readonly AppDbContext _db;
    
    public ClassRepository(AppDbContext db)
    {
        _db = db;
    }
    
    // Gets all classes from the database
    public async Task<List<Class>> GetAllAsync()
    {
        return await _db.Classes.ToListAsync();
    }

    // Gets a class by id
    public async Task<Class?> GetByIdAsync(Guid id)
    {
        return await _db.Classes.SingleOrDefaultAsync(x => x.Id == id);
    }

    // Checks if a class exists
    public async Task<bool> ClassExistsAsync(Guid id)
    {
        return await _db.Classes.AnyAsync(x => x.Id == id);
    }
}