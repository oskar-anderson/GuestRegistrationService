namespace DAL.App.DTO;

public class ParticipantUnified
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int ParticipantCount { get; set; } = 1;  // 1 for civilian, x for business
}