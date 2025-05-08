namespace Mud.Core.Dto.Party;

public class PartyMemberResponse
{
    public Guid CharacterId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string AccountUsername { get; set; } = string.Empty;
    public int Level { get; set; }
    public string ClassName { get; set; } = string.Empty;
    public bool IsReady { get; set; }
    public bool IsLeader { get; set; }
}

public static class PartyMemberExtension
{
    public static PartyMemberResponse ToResponse(this Entities.PartyMember partyMember)
    {
        return new PartyMemberResponse()
        {
            CharacterId = partyMember.CharacterId,
            Name = partyMember.Character.Name,
            AccountUsername = partyMember.Character.AccountUsername,
            Level = partyMember.Character.Level,
            ClassName = partyMember.Character.Class.Name,
            IsReady = partyMember.IsReady,
            IsLeader = partyMember.IsLeader
        };
    }
}