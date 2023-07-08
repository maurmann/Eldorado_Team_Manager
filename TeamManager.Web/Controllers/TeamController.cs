using Microsoft.AspNetCore.Mvc;
using TeamManager.Application.Services.Contracts;
using TeamManager.Domain.Entities;
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

        public IActionResult List()
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

        public IActionResult New()
        {
            return View("Form");
        }

        public IActionResult Edit(int id)
        {
            var team = _teamService.GetById(id);
            return View("Form", team);
        }

        public IActionResult Save(Team team)
        {
            ModelState.Remove("Id");

            if (ModelState.IsValid)
            {
                _teamService.Save(team);
                return RedirectToAction("List");
            }
            else
                return View("Form", team);
        }

    }
}
