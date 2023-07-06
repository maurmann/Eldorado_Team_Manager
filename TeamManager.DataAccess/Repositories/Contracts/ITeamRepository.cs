using TeamManager.Domain.Entities;

namespace TeamManager.DataAccess.Repositories.Contracts
{
    public interface ITeamRepository 
    {
        public IEnumerable<Team> GetAll();
        public Team GetById(int id);
        public void Delete(int id);
    }
}
