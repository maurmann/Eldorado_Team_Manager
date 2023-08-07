namespace TeamManager.Domain.Abstract.Common
{
    public class PaginatedFilter<T> where T : class
    {
        public T Filter { get; set; }
        public Pagination Pagination { get; set; }
    }
}
