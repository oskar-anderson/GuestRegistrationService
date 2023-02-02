using Contracts.DAL.App.Repositories;
using DAL.Base.EF;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Repositories;

public class ParticipantCivilianRepository : EFBaseRepository<DTO.ParticipantCivilian>, IParticipantCivilianRepository
{
    public ParticipantCivilianRepository(DbContext dbContext) : base(dbContext)
    {
    }
}