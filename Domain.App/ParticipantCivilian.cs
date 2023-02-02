using System;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Validation;

namespace Domain.App
{
    public class ParticipantCivilian : DomainEntityIdMetadata
    {
        public Guid EventId { get; set; } = default!;
        public EventRealLife? Event { get; set; }
        
        [MaxLength(255)]
        public string FirstName { get; set; } = default!;
        [MaxLength(255)]
        public string LastName { get; set; } = default!;
        [Validations.ValidEstonianId]
        public string NationalIdentificationNumber { get; set; } = default!;
        
        // This is un-normalized string value for UISelectOption.
        // This is unsafe as UISelectOption comes from Database and must be modifiable by spec.
        // If someone changes the PaymentType UISelectOption value the UISelectOption will have to default - this is what Google Forms does.
        [MaxLength(255, ErrorMessage = "Something is very wrong! Value from UISelectOption cannot reasonably be more than 255 chars!")]
        public string PaymentTypeValue { get; set; } = default!;
        
        [MaxLength(1500)]
        public string ExtraInfo { get; set; }
    }
}
