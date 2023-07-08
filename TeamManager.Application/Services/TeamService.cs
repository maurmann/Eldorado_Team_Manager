using TeamManager.Application.Services.Contracts;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Repositories;

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

        public Team GetById(int id)
        {
            var team = _teamRepository.GetById(id);
            return team;
        }

        public void Delete(int id)
        {
            _teamRepository.Delete(id);
        }

        public void Save(Team team)
        {
            if (team.Id == 0)
                _teamRepository.Insert(team);
            else 
                _teamRepository.Update(team);
        }
    }
}
