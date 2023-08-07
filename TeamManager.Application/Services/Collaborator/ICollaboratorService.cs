using TeamManager.Domain.Abstract.Collaborator;
using TeamManager.Domain.Abstract.Common;

namespace TeamManager.Application.Services.Collaborator
{
    public interface ICollaboratorService
    {
        Task<CollaboratorPaginatedList> GetPaginated(PaginatedFilter<CollaboratorFilter> paginatedFilter);
    }
}
