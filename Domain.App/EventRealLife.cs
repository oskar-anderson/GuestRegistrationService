using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Base;
using Domain.Validation;

namespace Domain.App
{
    public class EventRealLife : DomainEntityIdMetadata
    {
        [MaxLength(255, ErrorMessage = $"{nameof(Name)}")]
        public string Name { get; set; } = default!;
        [Validations.DateIsInTheFuture]
        public DateTime HappeningDate { get; set; }
        [MaxLength(255)]
        public string Place { get; set; } = default!;

        [MaxLength(1000)]
        public string ExtraInfo { get; set; } = default!;
        public ICollection<ParticipantCivilian>? CivilianParticipants { get; set; }
        public ICollection<ParticipantBusiness>? BusinessParticipants { get; set; }
        
    }
}
