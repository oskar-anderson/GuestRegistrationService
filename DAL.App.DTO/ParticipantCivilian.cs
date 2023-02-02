using Contracts.Domain;

namespace DAL.App.DTO;

public class ParticipantCivilian : IDomainEntityId
{
    public Guid Id { get; set; }
    
    public Guid EventId { get; set; }
    public EventRealLife? Event { get; set; }
    
    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalIdentificationNumber { get; set; } = default!;
    public string ExtraInfo { get; set; } = default!;
}