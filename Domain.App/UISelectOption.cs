using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.App;

public class UISelectOption : DomainEntityIdMetadata
{
    [MaxLength(255)]
    public string SelectGroupIdentifier { get; set; } = default!;

    [MaxLength(255)]
    public string DisplayedText { get; set; } = default!;

    public bool Disabled { get; set; }
    
    public bool Selected { get; set; }

    [MaxLength(255)]
    public string Value { get; set; } = default!;
}