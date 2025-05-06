using Mud.Core.Dto.Character;
using Mud.Core.Entities;

namespace Mud.Core.Dto.Party;

public class PartyResponse
{
    public DateTime CreatedAt { get; set; }
    public List<CharacterResponse> Members { get; set; } = [];
}

public static class PartyExtension
{
    public static PartyResponse ToResponse(this Entities.Party party)
    {
        return new PartyResponse()
        {
            CreatedAt = party.CreatedAt,
            Members = party.Members.Select(m => m.Character?.ToResponse()).ToList()!
        };
    }
}