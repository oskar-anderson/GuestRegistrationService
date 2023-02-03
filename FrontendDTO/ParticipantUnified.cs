namespace FrontendDTO;

public class ParticipantUnified
{
    public Guid Id { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Type { get; set; } = default!;
    public string Code { get; set; } = default!;
    public int ParticipantCount { get; set; } = 1;  // 1 for civilian, x for business
    
    public ParticipantUnified MapDal(DAL.App.DTO.ParticipantUnified dalDto)
    {
        return new ParticipantUnified()
        {
            Id = dalDto.Id,
            Name = dalDto.Name,
            Type = dalDto.Type,
            Code = dalDto.Code,
            ParticipantCount = dalDto.ParticipantCount
        };
    }
}