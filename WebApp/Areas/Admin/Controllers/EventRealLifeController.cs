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
    
    
    [HttpGet("EventRealLife")]
    public async Task<IActionResult> Index()
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
        /*
        var events = await _repository.GetAllAsyncBase();
        var frontEvents = events.Select(x => FrontendDTO.EventRealLife.MapFromDal(x)).ToList();
        var limitedFrontEvents = frontEvents.Select(x => new FrontendDTO.EventRealLifeLimitedOnlyCount()
        {
            Id = x.Id,
            Name = x.Name,
            ExtraInfo = x.ExtraInfo,
            HappeningDate = x.HappeningDate,
            Place = x.Place,
            ParticipantCount = 5
        });
        return View(limitedFrontEvents);
        */
    }
    
    
    [HttpGet("EventRealLife/Details/{id}")]
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
    
    [HttpGet("EventRealLife/Create")]
    public IActionResult Create()
    {
        return View(new EventRealLife()
        {
            Id = new Guid()
        });
    }
    
    [HttpPost("EventRealLife/Create")]
    public IActionResult Create(EventRealLife eventRealLife)
    {
        if (!ModelState.IsValid) return View(eventRealLife);
        Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(eventRealLife));
        _repository.Add(eventRealLife.MapToDal());
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("EventRealLife/Edit/{id}")]
    public async Task<IActionResult> Edit(Guid id)
    {
        var eventRealLife = await _repository.FirstOrDefault(id, false);
        if (eventRealLife == null)
        {
            return NotFound();
        }
        return View(EventRealLife.MapFromDal(eventRealLife));
    }
    
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost("EventRealLife/Edit/{id}")]
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
    
    [HttpGet("EventRealLife/Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var eventRealLife = await _repository.FirstOrDefault(id);
        if (eventRealLife == null)
        {
            return NotFound();
        }

        return View(EventRealLife.MapFromDal(eventRealLife));
    }
    
    [HttpPost("EventRealLife/Delete/{id}"), ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        var eventRealLife = await _repository.FirstOrDefault(id);
        if (eventRealLife == null)
        {
            return NotFound();
        }
        await _repository.RemoveAsync(eventRealLife);
        return RedirectToAction(nameof(Index));
    }
}