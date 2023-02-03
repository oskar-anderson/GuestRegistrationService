using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Pages.Admin.Views.EventRealLife;


public class DetailsModel : PageModel
{
    private readonly DAL.App.EF.AppDbContext _context;
    private readonly DAL.App.EF.Repositories.EventRealLifeRepository _repository;

    public DetailsModel(DAL.App.EF.AppDbContext context, DAL.App.EF.Repositories.EventRealLifeRepository repository)
    {
        _context = context;
        _repository = repository;
    }

    public FrontendDTO.EventRealLife EventRealLife { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(Guid id)
    {
        var eventDal = await _repository.FirstOrDefault(id);
        if (eventDal == null)
        {
            return NotFound();
        }
        EventRealLife = new FrontendDTO.EventRealLife().MapDal(eventDal);
        
        return Page();
    }
}

