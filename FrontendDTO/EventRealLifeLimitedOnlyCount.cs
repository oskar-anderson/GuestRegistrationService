namespace FrontendDTO;

public class EventRealLifeLimitedOnlyCount
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime HappeningDate { get; set; }
    public int ParticipantCount { get; set; }
    
    public EventRealLifeLimitedOnlyCount MapDal(DAL.App.DTO.EventRealLifeLimitedOnlyCount dalDto)
    {
        return new EventRealLifeLimitedOnlyCount()
        {
            Id = dalDto.Id,
            Name = dalDto.Name,
            HappeningDate = dalDto.HappeningDate,
            ParticipantCount = dalDto.ParticipantCount
        };
    }
}