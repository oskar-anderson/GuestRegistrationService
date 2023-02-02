using Contracts.DAL.App.Repositories;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class ParticipantBusinessRepository : EFBaseRepository<DTO.ParticipantBusiness>, IParticipantBusinessRepository
{
    public ParticipantBusinessRepository(DbContext dbContext) : base(dbContext)
    {
    }
}