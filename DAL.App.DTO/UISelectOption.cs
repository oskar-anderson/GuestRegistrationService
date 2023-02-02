using Contracts.Domain;

namespace DAL.App.DTO;

public class UISelectOption : IDomainEntityId
{
    public Guid Id { get; set; }
    
    public string SelectGroupIdentifier { get; set; } = default!;
    
    public string DisplayedText { get; set; } = default!;

    public bool Disabled { get; set; }
    
    public bool Selected { get; set; }
    
    public string Value { get; set; } = default!;
}