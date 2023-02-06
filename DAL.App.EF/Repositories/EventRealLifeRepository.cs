using System.Linq;
using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class EventRealLifeRepository : EFBaseRepository<DTO.EventRealLife>, IEventRealLifeRepository
{
    public EventRealLifeRepository(AppDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<IEnumerable<EventRealLifeLimitedOnlyCount>> GetAllBetweenDatesLimitedAsync(DateTime before, DateTime after)
    {
        return await RepoDbSet
            .Where(e => e.HappeningDate >= before && e.HappeningDate < after)
            .Select(e => new EventRealLifeLimitedOnlyCount()
            {
                Id = e.Id, 
                Name = e.Name,
                HappeningDate = e.HappeningDate,
                Place = e.Place,
                ExtraInfo = e.ExtraInfo,
                ParticipantCount = e.CivilianParticipants!.Count + e.BusinessParticipants!.Select(bp => bp.ParticipantCount).Sum()
            }).ToListAsync();
    }

    public async Task<EventRealLifeLimitedUnifiedParticipants?> GetEventRealLifeLimitedUnified(Guid id)
    {
        var eventRealLife = await RepoDbSet.FirstOrDefaultAsync(e => e.Id == id);
        if (eventRealLife == null)
        {
            return null;
        }
        return new EventRealLifeLimitedUnifiedParticipants()
        {
            Id = eventRealLife.Id,
            Name = eventRealLife.Name,
            HappeningDate = eventRealLife.HappeningDate,
            Place = eventRealLife.Place,
            ExtraInfo = eventRealLife.ExtraInfo,
            Participants = eventRealLife.BusinessParticipants!
                .Select(bp => new ParticipantUnified()
                {
                    Id = bp.Id,
                    Code = bp.CompanyRegistrationCode,
                    Name = bp.LegalName,
                    ParticipantCount = bp.ParticipantCount,
                    Type = "legal"
                }).Concat(eventRealLife.CivilianParticipants!.Select(cp => new ParticipantUnified()
                    {
                        Id = cp.Id,
                        Code = cp.NationalIdentificationNumber,
                        Name = cp.FirstName + " " + cp.LastName,
                        ParticipantCount = 1, 
                        Type = "citizen"
                    })
                ).ToList()
            
        };
    }
}
