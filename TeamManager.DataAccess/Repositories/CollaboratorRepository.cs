using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TeamManager.DataAccess.EF;
using TeamManager.Domain.Abstract.Collaborator;
using TeamManager.Domain.Abstract.Common;
using TeamManager.Domain.Entities;
using TeamManager.Domain.Repositories;

namespace TeamManager.DataAccess.Repositories
{
    public class CollaboratorRepository : ICollaboratorRepository
    {
        private readonly TeamManagerDbContext _dbContext;

        public CollaboratorRepository(TeamManagerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Collaborator>> GetPaginated(PaginatedFilter<CollaboratorFilter> paginatedFilter)
        {
            var collaboratorPagedList = await _dbContext.Collaborators
                 .AsNoTracking()
                 .Where(Filter(paginatedFilter.Filter))
                 .OrderBy(x => x.Name)
                 .Skip(100)
                 .Take(10)
                 .ToListAsync();

            return collaboratorPagedList;
        }

        public async Task<long> CountRows(CollaboratorFilter collaboratorFilter)
        {
            var rows = await _dbContext.Collaborators
                 .AsNoTracking()
                 .Where(Filter(collaboratorFilter))
                 .LongCountAsync();

            return rows;
        }

        public Collaborator? GetById(int id)
        {
            var collaborator = _dbContext.Collaborators
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            return collaborator;
        }

        public void Delete(int id)
        {
            var collaborator = _dbContext.Collaborators
                .FirstOrDefault(x => x.Id == id);

            if (collaborator != null)
            {
                _dbContext.Remove(collaborator);
                _dbContext.SaveChanges();
            }
        }

        public void Insert(Collaborator collaborator)
        {
            _dbContext.Collaborators.Add(collaborator);
            _dbContext.SaveChanges();
        }

        public void Update(Collaborator collaborator)
        {
            _dbContext.Collaborators.Attach(collaborator);
            _dbContext.Entry(collaborator).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        private Expression<Func<Collaborator, bool>> Filter(CollaboratorFilter collaboratorFilter)
        {
            return x => collaboratorFilter.Name != null && x.Name.Contains(collaboratorFilter.Name);
        }
    }
}
