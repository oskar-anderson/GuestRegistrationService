using System.ComponentModel.DataAnnotations;

namespace FrontendDTO;

public class EventRealLife
{
    public Guid Id { get; set; }
    
    [MaxLength(255, ErrorMessage = $"{nameof(Name)} must be shorter than 255 characters!")]
    public string Name { get; set; } = default!;
    public DateTime HappeningDate { get; set; }
    public string Place { get; set; } = default!;
    
    public string ExtraInfo { get; set; } = default!;
    public ICollection<ParticipantCivilian>? CivilianParticipants { get; set; }
    public ICollection<ParticipantBusiness>? BusinessParticipants { get; set; }

    
    public EventRealLife MapDal(DAL.App.DTO.EventRealLife dalDto)
    {
        return new EventRealLife()
        {
            Id = dalDto.Id,
            Name = dalDto.Name,
            HappeningDate = dalDto.HappeningDate,
            Place = dalDto.Place,
            ExtraInfo = dalDto.ExtraInfo,
            CivilianParticipants = dalDto.CivilianParticipants.Select(x => new ParticipantCivilian().MapDal(x)).ToList(),
            BusinessParticipants = dalDto.BusinessParticipants.Select(x => new ParticipantBusiness().MapDal(x)).ToList()
        };
    }
}