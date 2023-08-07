using TeamManager.Domain.Abstract.Collaborator;
using TeamManager.Domain.Abstract.Common;
using TeamManager.Domain.Entities;

namespace TeamManager.Domain.Repositories
{
    public interface ICollaboratorRepository
    {
        Task<IEnumerable<Collaborator>> GetPaginated(PaginatedFilter<CollaboratorFilter> paginatedFilter);
        Task<long> CountRows(CollaboratorFilter collaboratorFilter);
        Collaborator? GetById(int id);
        void Delete(int id);
        void Insert(Collaborator collaborator);
        void Update(Collaborator collaborator);
    }
}
