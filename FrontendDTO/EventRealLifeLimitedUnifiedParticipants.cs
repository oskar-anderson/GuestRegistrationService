namespace FrontendDTO;

public class EventRealLifeLimitedUnifiedParticipants
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime HappeningDate { get; set; }
    public string Place { get; set; } = default!;
    
    public string ExtraInfo { get; set; } = default!;
    public List<ParticipantUnified> Participants { get; set; } = default!;
    
    public EventRealLifeLimitedUnifiedParticipants MapDal(DAL.App.DTO.EventRealLifeLimitedUnifiedParticipants dalDto)
    {
        return new EventRealLifeLimitedUnifiedParticipants()
        {
            Id = dalDto.Id,
            Name = dalDto.Name,
            HappeningDate = dalDto.HappeningDate,
            Place = dalDto.Place,
            ExtraInfo = dalDto.ExtraInfo,
            Participants = dalDto.Participants.Select(x => new ParticipantUnified().MapDal(x)).ToList(),
        };
    }
}