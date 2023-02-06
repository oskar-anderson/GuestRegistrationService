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


    public static EventRealLife MapFromDal(DAL.App.DTO.EventRealLife dalDto)
    {
        return new EventRealLife()
        {
            Id = dalDto.Id,
            Name = dalDto.Name,
            HappeningDate = dalDto.HappeningDate,
            Place = dalDto.Place,
            ExtraInfo = dalDto.ExtraInfo,
        };
    }

    public DAL.App.DTO.EventRealLife MapToDal()
    {
        return new DAL.App.DTO.EventRealLife()
        {
            Id = Id,
            Name = Name,
            HappeningDate = HappeningDate,
            Place = Place,
            ExtraInfo = ExtraInfo,
        };
    }
}