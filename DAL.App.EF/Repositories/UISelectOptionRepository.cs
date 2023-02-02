using Contracts.DAL.App.Repositories;
using DAL.App.DTO;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class UISelectOptionRepository : EFBaseRepository<DTO.UISelectOption>, IUISelectOptionRepository
{
    public UISelectOptionRepository(DbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<UISelectOption>> GetAllByGroupIdentifierAsync(string groupIdentifier)
    {
        return await RepoDbSet.Where(x => x.SelectGroupIdentifier == groupIdentifier).ToListAsync();
    }
}