using Microsoft.AspNetCore.Mvc;
using TeamManager.Application.Services.Contracts;
using TeamManager.Web.Models.Team;

namespace TeamManager.Web.Controllers
{
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult Index()
        {
            var teams = _teamService.ListAll();
            var teamListViewModel = new TeamListViewModel(teams);
            return View(teamListViewModel);
        }
    }
}
