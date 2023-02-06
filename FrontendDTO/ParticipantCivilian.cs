using System.ComponentModel.DataAnnotations;

namespace FrontendDTO;

public class ParticipantCivilian
{
    public Guid Id { get; set; }
    
    public Guid EventId { get; set; }

    public string FirstName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public string NationalIdentificationNumber { get; set; } = default!;
    
    [MaxLength(255, ErrorMessage = $"{nameof(PaymentTypeValue)} must be shorter than 255 characters!")]
    public string PaymentTypeValue { get; set; } = default!;
    public string ExtraInfo { get; set; } = default!;

    public ParticipantCivilian MapFromDal(DAL.App.DTO.ParticipantCivilian dalDto)
    {
        return new ParticipantCivilian()
        {
            Id = dalDto.Id,
            EventId = dalDto.EventId,
            FirstName = dalDto.FirstName,
            LastName = dalDto.LastName,
            NationalIdentificationNumber = dalDto.NationalIdentificationNumber,
            PaymentTypeValue = dalDto.PaymentTypeValue,
            ExtraInfo = dalDto.ExtraInfo,
        };
    }
}