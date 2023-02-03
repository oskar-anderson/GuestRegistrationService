using System.ComponentModel.DataAnnotations;

namespace FrontendDTO;

public class ParticipantBusiness
{
    public Guid Id { get; set; }
    
    public Guid EventId { get; set; }
    public string LegalName { get; set; } = default!;
    public string CompanyRegistrationCode { get; set; } = default!;
    
    [Range(1, int.MaxValue, ErrorMessage = $"{nameof(ParticipantCount)} is not valid, cannot be smaller than 1!")]
    public int ParticipantCount { get; set; }

    [MaxLength(255, ErrorMessage = $"{nameof(PaymentTypeValue)} must be shorter than 255 characters!")]
    public string PaymentTypeValue { get; set; } = default!;
    
    public string ExtraInfo { get; set; } = default!;

    public ParticipantBusiness MapDal(DAL.App.DTO.ParticipantBusiness dalDto)
    {
        return new ParticipantBusiness()
        {
            Id = dalDto.Id,
            EventId = dalDto.EventId,
            LegalName = dalDto.LegalName,
            CompanyRegistrationCode = dalDto.CompanyRegistrationCode,
            ParticipantCount = dalDto.ParticipantCount,
            PaymentTypeValue = dalDto.PaymentTypeValue,
            ExtraInfo = dalDto.ExtraInfo
        };
    }
}