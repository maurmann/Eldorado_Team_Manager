using TeamManager.Domain.Abstract.Collaborator;

namespace TeamManager.Web.Models.Collaborator
{
    public class CollaboratorListViewModel
    {
        public CollaboratorPaginatedList PaginatedList { get; set; }

        public CollaboratorListViewModel(CollaboratorPaginatedList paginatedList)
        {
            PaginatedList = paginatedList;
        }

        public CollaboratorListViewModel()
        {
            PaginatedList = new CollaboratorPaginatedList(new List<Domain.Entities.Collaborator>(), new CollaboratorFilter(), new Domain.Abstract.Common.Pagination(0, 0, 0));

        }
    }
}
