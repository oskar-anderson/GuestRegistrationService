using Contracts.Domain;

namespace DAL.App.DTO;

public class EventRealLife : IDomainEntityId
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = default!;
    public DateTime HappeningDate { get; set; }
    public string Place { get; set; } = default!;
    
    public string ExtraInfo { get; set; } = default!;
    public ICollection<ParticipantCivilian> CivilianParticipants { get; set; } = default!;
    public ICollection<ParticipantBusiness> BusinessParticipants { get; set; } = default!;
}