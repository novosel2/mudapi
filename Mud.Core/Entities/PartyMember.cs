using System.ComponentModel.DataAnnotations;
using Microsoft.IdentityModel.Tokens;

namespace Mud.Core.Entities;

public class PartyMember
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    public Guid CharacterId { get; set; }
    
    [Required]
    public Guid PartyId { get; set; }

    [Required] 
    public bool IsReady { get; set; } = false;
    
    [Required] 
    public bool IsLeader { get; set; } = false;
    
    [Required]
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

    public Character? Character { get; set; }
    public Party? Party { get; set; }
}