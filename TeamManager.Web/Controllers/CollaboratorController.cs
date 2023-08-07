using Microsoft.AspNetCore.Mvc;
using TeamManager.Application.Services.Collaborator;
using TeamManager.Domain.Abstract.Collaborator;
using TeamManager.Domain.Abstract.Common;
using TeamManager.Web.Models.Collaborator;

namespace TeamManager.Web.Controllers
{
    public class CollaboratorController : Controller
    {
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }

        public IActionResult Index()
        {
            return View("List", new CollaboratorListViewModel() );
        }

        public async Task<IActionResult> List([FromQuery] PaginatedFilter<CollaboratorFilter> paginatedFilter)
        {
            var collaborators = await _collaboratorService.GetPaginated(paginatedFilter);
            var collaboratorListViewModel = new CollaboratorListViewModel(collaborators);

            return View(collaboratorListViewModel);
        }
    }
}
