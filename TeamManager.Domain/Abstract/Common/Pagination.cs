namespace TeamManager.Domain.Abstract.Common
{
    public class Pagination
    {
        public int PageSize { get; private set; }
        public int PageNumber { get; private set; }
        public long RowCount { get; private set; }

        public Pagination(int pageSize, int pageNumber, long rowCount)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            RowCount = rowCount;
        }

        public Pagination AddRowCount(long rowCount)
        {
            RowCount = rowCount;
            return this;
        }
    }
}
