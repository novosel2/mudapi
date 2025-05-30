﻿using Mud.Core.Dto.Party;
using Mud.Core.Entities;
using Mud.Core.Exceptions;
using Mud.Core.IRepositories;
using Mud.Core.IServices;

namespace Mud.Core.Services;

public class PartyService : IPartyService
{
    private readonly IPartyRepository _partyRepository;
    private readonly Guid _accountId;
    
    public PartyService(IPartyRepository partyRepository, CurrentAccountService currentAccountService)
    {
        _partyRepository = partyRepository;
        _accountId = currentAccountService.CurrentAccountId ?? throw new UnauthorizedAccessException("Unauthorized access.");
    }
    
    // Gets all parties from the database
    public async Task<List<PartyResponse>> GetAllAsync()
    {
        List<Party> parties = await _partyRepository.GetAllAsync();
        List<PartyResponse> partyResponses = parties.Select(p => p.ToResponse()).ToList();
        
        return partyResponses;
    }

    // Gets all parties that are available for joining
    public async Task<List<PartyResponse>> GetAllAvailableAsync()
    {
        List<Party> parties = await _partyRepository.GetAllAvailableAsync();
        List<PartyResponse> partyResponses = parties.Select(p => p.ToResponse()).ToList();
        
        return partyResponses;
    }

    // Creates a party in the database
    public async Task<PartyResponse> CreatePartyAsync()
    {
        Party? party = await _partyRepository.GetByLeaderIdAsync(_accountId);
        
        if (party != null)
            throw new AlreadyExistsException("Account already has a party.");
        
        party = new Party();
        PartyMember leader = new PartyMember()
        {
            CharacterId = _accountId,
            PartyId = party.Id,
            IsLeader = true,
            IsReady = false
        };

        party.Members.Add(leader);
        
        party = await _partyRepository.CreatePartyAsync(party);
        party.Members.Add(leader);

        if (!await _partyRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to save party to the database.");
        
        return party.ToResponse();        
    }

    // Deletes a party from the database
    public async Task DeletePartyAsync(Guid partyId)
    {
        Party party = await _partyRepository.GetByIdAsync(partyId)
            ?? throw new NotFoundException($"Party not found, ID: {partyId}");

        if (!party.Members.Any(m => m.IsLeader == true && m.Id == _accountId))
            throw new ForbiddenException("Not authorized to delete this party.");

        _partyRepository.DeleteParty(party);

        if (!await _partyRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to delete party from the database.");
    }

    public async Task JoinPartyAsync(Guid partyId)
    {
        Party party = await _partyRepository.GetByIdAsync(partyId)
            ?? throw new NotFoundException($"Party not found, ID: {partyId}");

        if (party.Members.Any(m => m.CharacterId == _accountId))
            throw new AlreadyExistsException("Account already joined this party.");

        if (party.Members.Count >= 4)
            throw new AlreadyExistsException("Party is full.");

        PartyMember partyMember = new PartyMember()
        {
            CharacterId = _accountId,
            PartyId = party.Id,
            IsLeader = false,
            IsReady = false
        };

        party.Members.Add(partyMember);

        if (!await _partyRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to save party member to the database.");
    }

    public async Task LeavePartyAsync()
    {
        Party party = await _partyRepository.GetByPartyMemberIdAsync(_accountId)
            ?? throw new NotFoundException("Account is not in any parties.");

        PartyMember partyMember = party.Members.Single(m => m.CharacterId == _accountId);

        if (partyMember.IsLeader)
            throw new ForbiddenException("Party leader cannot leave the party. Please delete the party instead.");

        party.Members.Remove(partyMember);

        if (!await _partyRepository.IsSavedAsync())
            throw new DbSavingFailedException("Failed to leave party.");
    }
}