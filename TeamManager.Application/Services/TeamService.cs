using TeamManager.Application.Services.Contracts;
using TeamManager.DataAccess.Repositories.Contracts;
using TeamManager.Domain.Entities;

namespace TeamManager.Application.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public IEnumerable<Team> ListAll()
        {
            var teams = _teamRepository.GetAll();
            return teams;
        }
    }
}
