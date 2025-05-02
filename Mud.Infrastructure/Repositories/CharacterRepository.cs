using Microsoft.EntityFrameworkCore;
using Mud.Core.Entities;
using Mud.Core.IRepositories;
using Mud.Infrastructure.Data;

namespace Mud.Infrastructure.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly AppDbContext _db;

    public CharacterRepository(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task<List<Character>> GetAllAsync()
    {
        return await _db.Characters.ToListAsync();
    }

    public Task<Character> AddAsync(Character character)
    {
        throw new NotImplementedException();
    }
}