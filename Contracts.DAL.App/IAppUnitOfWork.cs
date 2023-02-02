using Contracts.DAL.App.Repositories;

namespace Contracts.DAL.App;

public interface IAppUnitOfWork
{
    IEventRealLifeRepository Events { get; }
    IParticipantBusinessRepository ParticipantBusinesses { get; }
    IParticipantCivilianRepository ParticipantCivilians { get; }
    IUISelectOptionRepository UiSelectOptions { get; }
}