using TeamManager.Domain.Entities;

namespace TeamManager.DataAccess.Repositories.Contracts
{
    public interface ITeamRepository 
    {
        public IEnumerable<Team> GetAll();
    }
}
