using Microsoft.EntityFrameworkCore;
using TeamManager.DataAccess.EF;
using TeamManager.DataAccess.Repositories.Contracts;
using TeamManager.Domain.Entities;

namespace TeamManager.DataAccess.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private readonly TeamManagerDbContext _dbContext;

        public TeamRepository(TeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Team> GetAll()
        {
            return _dbContext.Teams
                 .AsNoTracking()
                 .ToList();
        }
    }
}
