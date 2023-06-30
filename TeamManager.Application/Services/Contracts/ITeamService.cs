using TeamManager.Domain.Entities;

namespace TeamManager.Application.Services.Contracts
{
    public interface ITeamService 
    {
        public IEnumerable<Team> ListAll();
    }
}
