using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using DAL.App.EF.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF;

public class AppUnitOfWork : IAppUnitOfWork
{
    protected readonly AppDbContext UOWDbContext;
    
    public AppUnitOfWork(AppDbContext uowDbContext)
    {
        UOWDbContext = uowDbContext;
    }
    
    public IEventRealLifeRepository Events => new EventRealLifeRepository(UOWDbContext);
    public IParticipantBusinessRepository ParticipantBusinesses => new ParticipantBusinessRepository(UOWDbContext);
    public IParticipantCivilianRepository ParticipantCivilians => new ParticipantCivilianRepository(UOWDbContext);
    public IUISelectOptionRepository UiSelectOptions => new UISelectOptionRepository(UOWDbContext);
}