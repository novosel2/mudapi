
namespace Mud.Core.Dto.Party;

public class PartyResponse
{
    public Guid PartyId { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<PartyMemberResponse> Members { get; set; } = [];
}

public static class PartyExtension
{
    public static PartyResponse ToResponse(this Entities.Party party)
    {
        return new PartyResponse()
        {
            PartyId = party.Id,
            CreatedAt = party.CreatedAt,
            Members = party.Members.Select(m => m.ToResponse()).ToList()
        };
    }
}