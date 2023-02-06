using DAL.App.EF;
using Microsoft.AspNetCore.Mvc;
using Contracts.DAL.App.Repositories;
using FrontendDTO;

namespace WebApp.Areas.Admin.Controllers;

[Area("Admin")]
public class EventRealLifeController : Controller
{
    private readonly IEventRealLifeRepository _repository;

    public EventRealLifeController(DAL.App.EF.AppDbContext context)
    {
        _repository = new DAL.App.EF.AppUnitOfWork(context).Events;
    }
    
    
    // GET: EventRealLife
    public IActionResult Index()
    {
        var events = new List<FrontendDTO.EventRealLifeLimitedOnlyCount>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Name = "Big Event",
                ExtraInfo = "Super awesome event description",
                HappeningDate = new DateTime(2023, 2, 10, 14, 30, 00),
                Place = "Tallinn",
                ParticipantCount = 5
            }
        };
        return View(events);
    }
    
        
    // GET: EventRealLife/Details/5
    public async Task<IActionResult> Details(Guid id)
    {
        var eventDal = await _repository.FirstOrDefault(id);
        if (eventDal == null)
        {
            return NotFound();
        }
        var eventRealLife = EventRealLife.MapFromDal(eventDal);
        
        return View(eventRealLife);
    }
    
    // GET: EventRealLife/Create
    public IActionResult Create()
    {
        return View(new EventRealLife());
    }
    
    // POST: EventRealLife/Create
    [HttpPost]
    public IActionResult Create(EventRealLife eventRealLife)
    {
        if (!ModelState.IsValid) return View(eventRealLife);
        _repository.Add(eventRealLife.MapToDal());
        return RedirectToAction(nameof(Index));
    }

    // GET: EventRealLife/Edit/5
    public async Task<IActionResult> Edit(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var eventRealLife = await _repository.FirstOrDefault(id.Value, false);
        if (eventRealLife == null)
        {
            return NotFound();
        }
        return View(EventRealLife.MapFromDal(eventRealLife));
    }
    
    // POST: EventRealLife/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    public async Task<IActionResult> Edit(Guid id, EventRealLife eventRealLife)
    {
        if (id != eventRealLife.Id)
        {
            return NotFound();
        }
        if (!ModelState.IsValid) return View(eventRealLife);
        
        await _repository.UpdateAsync(eventRealLife.MapToDal());
        return RedirectToAction(nameof(Index));
    }
    
    // GET: EventRealLife/Delete/5
    public async Task<IActionResult> Delete(Guid? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var eventRealLife = await _repository.FirstOrDefault(id.Value);
        if (eventRealLife == null)
        {
            return NotFound();
        }

        return View(EventRealLife.MapFromDal(eventRealLife));
    }
}