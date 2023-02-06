namespace DAL.App.DTO;

public class EventRealLifeLimitedOnlyCount
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime HappeningDate { get; set; }
    public string Place { get; set; } = default!;
    public string ExtraInfo { get; set; } = default!;
    public int ParticipantCount { get; set; }
}