using Contracts.DAL.Base;
using DAL.App.DTO;

namespace Contracts.DAL.App.Repositories;

public interface IUISelectOptionRepository : IBaseRepository<UISelectOption>
{
    Task<IEnumerable<UISelectOption>> GetAllByGroupIdentifierAsync(string groupIdentifier);
}