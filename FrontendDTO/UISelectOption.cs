using System.ComponentModel.DataAnnotations;

namespace FrontendDTO;

public class UISelectOption
{
    public Guid Id { get; set; }
    [MaxLength(255, ErrorMessage = $"{nameof(SelectGroupIdentifier)} must be shorter than 255 characters!")]
    public string SelectGroupIdentifier { get; set; } = default!;
    
    [MaxLength(255, ErrorMessage = $"{nameof(DisplayedText)} must be shorter than 255 characters!")]
    public string DisplayedText { get; set; } = default!;

    public bool Disabled { get; set; }
    
    public bool Selected { get; set; }
    
    [MaxLength(255, ErrorMessage = $"{nameof(Value)} must be shorter than 255 characters!")]
    public string Value { get; set; } = default!;
    
    public UISelectOption MapDal(DAL.App.DTO.UISelectOption dalDto)
    {
        return new UISelectOption()
        {
            Id = dalDto.Id,
            SelectGroupIdentifier = dalDto.SelectGroupIdentifier,
            DisplayedText = dalDto.DisplayedText,
            Disabled = dalDto.Disabled,
            Selected = dalDto.Selected,
            Value = dalDto.Value
        };
    }
}