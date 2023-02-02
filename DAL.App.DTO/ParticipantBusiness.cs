using Contracts.Domain;

namespace DAL.App.DTO;

public class ParticipantBusiness : IDomainEntityId
{
    public Guid Id { get; set; }
    
    public Guid EventId { get; set; }
    public EventRealLife? Event { get; set; }
    
    public string LegalName { get; set; } = default!;
    public string CompanyRegistrationCode { get; set; } = default!;
    
    public int ParticipantCount { get; set; }
    
    public string ExtraInfo { get; set; } = default!;
}