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

        public IActionResult List()
        {
            var teams = _teamService.ListAll();
            var teamListViewModel = new TeamListViewModel(teams);
            return View(teamListViewModel);
        }

        public IActionResult Form(int id)
        {
            var teams = _teamService.ListAll();
            var teamListViewModel = new TeamListViewModel(teams);
            return View(teamListViewModel);
        }

        public IActionResult DeleteConfirm(int id)
        {
            var team = _teamService.GetById(id);
            return View(team);
        }

        public IActionResult DeleteExecute(int id)
        {
            _teamService.Delete(id);
            return RedirectToAction("List");
        }
    }
}
