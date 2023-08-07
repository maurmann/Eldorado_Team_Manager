using TeamManager.Domain.Abstract.Common;

namespace TeamManager.Domain.Abstract.Collaborator
{
    public class CollaboratorPaginatedList
    {
        public IEnumerable<Entities.Collaborator> Collaborators { get; set; }
        public CollaboratorFilter Filter { get; set; }
        public Pagination Pagination { get; set; }

        public CollaboratorPaginatedList(IEnumerable<Entities.Collaborator> collaborators, CollaboratorFilter collaboratorFilter, Pagination pagination)
        {
            Collaborators = collaborators;
            Filter = collaboratorFilter;
            Pagination = pagination;
        }
    }
}
