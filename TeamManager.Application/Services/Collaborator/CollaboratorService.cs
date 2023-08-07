using TeamManager.Domain.Abstract.Collaborator;
using TeamManager.Domain.Abstract.Common;
using TeamManager.Domain.Repositories;

namespace TeamManager.Application.Services.Collaborator
{
    public class CollaboratorService : ICollaboratorService
    {
        private readonly ICollaboratorRepository _collaboratorRepository;

        public CollaboratorService(ICollaboratorRepository collaboratorRepository)
        {
            _collaboratorRepository = collaboratorRepository;
        }

        public async Task<CollaboratorPaginatedList> GetPaginated(PaginatedFilter<CollaboratorFilter> paginatedFilter)
        {
            var getPaginatedTask = _collaboratorRepository.GetPaginated(paginatedFilter);
            var countRowsTask = _collaboratorRepository.CountRows(paginatedFilter.Filter);
            await Task.WhenAll(getPaginatedTask, countRowsTask);

            var collaboratorPaginatedList = new CollaboratorPaginatedList(getPaginatedTask.Result, 
                paginatedFilter.Filter, 
                paginatedFilter.Pagination.AddRowCount(countRowsTask.Result));

            return collaboratorPaginatedList;
        }
    }
}
