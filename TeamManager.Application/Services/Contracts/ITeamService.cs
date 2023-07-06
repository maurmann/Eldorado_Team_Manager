using TeamManager.Domain.Entities;

namespace TeamManager.Application.Services.Contracts
{
    public interface ITeamService
    {
        public IEnumerable<Team> ListAll();
        public Team GetById(int id);
        public void Delete(int id);
    }
}
