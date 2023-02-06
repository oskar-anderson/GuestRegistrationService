namespace FrontendDTO;

public class EventRealLifeLimitedOnlyCount
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime HappeningDate { get; set; }
    public string Place { get; set; } = default!;
    
    public string ExtraInfo { get; set; } = default!;
    public int ParticipantCount { get; set; }
    
    
    public EventRealLifeLimitedOnlyCount MapFromDal(DAL.App.DTO.EventRealLifeLimitedOnlyCount dalDto)
    {
        return new EventRealLifeLimitedOnlyCount()
        {
            Id = dalDto.Id,
            Name = dalDto.Name,
            HappeningDate = dalDto.HappeningDate,
            Place = dalDto.Place,
            ExtraInfo = dalDto.ExtraInfo,
            ParticipantCount = dalDto.ParticipantCount
        };
    }
}