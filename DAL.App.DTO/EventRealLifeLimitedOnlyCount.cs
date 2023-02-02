namespace DAL.App.DTO;

public class EventRealLifeLimitedOnlyCount
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public DateTime HappeningDate { get; set; }
    public int ParticipantCount { get; set; }
}