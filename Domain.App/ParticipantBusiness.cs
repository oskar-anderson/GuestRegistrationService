using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App
{
    public class ParticipantBusiness : DomainEntityIdMetadata
    {
        public Guid EventId { get; set; }
        public EventRealLife? Event { get; set; }
        
        [MaxLength(255)]
        public string LegalName { get; set; } = default!;
        [MaxLength(255)]
        public string CompanyRegistrationCode { get; set; } = default!;
        
        [Range(1, int.MaxValue)]
        public int ParticipantCount { get; set; }
        
        // This is un-normalized string value for UISelectOption.
        // This is unsafe as UISelectOption comes from Database and must be modifiable by spec.
        // If someone changes the PaymentType UISelectOption value the UISelectOption will have to default - this is what Google Forms does.
        [MaxLength(255)]
        public string PaymentTypeValue { get; set; } = default!;
        
        [MaxLength(5000)]
        public string ExtraInfo { get; set; }
    }
}
