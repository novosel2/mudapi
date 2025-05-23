﻿using Microsoft.EntityFrameworkCore;
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
    
    // Gets all characters from the database
    public async Task<List<Character>> GetAllAsync()
    {
        return await _db.Characters
            .Include(c => c.Class)
            .ToListAsync();
    }

    // Gets a character by id.
    public async Task<Character?> GetByIdAsync(Guid id)
    {
        return await _db.Characters
            .Include(c => c.Class)
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    // Adds a character to the database
    public async Task<Character> AddAsync(Character character)
    {
        var characterEntry = await _db.Characters.AddAsync(character);
        
        return characterEntry.Entity;
    }

    // Updates a character in the database
    public Task<Character> UpdateAsync(Character existingCharacter, Character updatedCharacter)
    {
        _db.Entry(existingCharacter).CurrentValues.SetValues(updatedCharacter);
        _db.Entry(existingCharacter).State = EntityState.Modified;
        
        return Task.FromResult(existingCharacter);
    }

    // Deletes a character in the database
    public Task<Character> DeleteAsync(Character character)
    {
        var characterEntry = _db.Characters.Remove(character);
        
        return Task.FromResult(characterEntry.Entity);
    }

    public async Task<bool> AccountCharacterExistsAsync(Guid accountId)
    {
        return await _db.Characters.AnyAsync(x => x.Id == accountId);
    }

    // Checks if any changes are saved to the database. Returns true if there are changes saved, false otherwise.
    public async Task<bool> IsSavedAsync()
    {
        int saved = await _db.SaveChangesAsync();
        
        return saved > 0;
    }
}