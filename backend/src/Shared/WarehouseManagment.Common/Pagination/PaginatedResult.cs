namespace WarehouseManagment.Common.Pagination
{
    public class PaginatedResult<T>
    {
        public PaginatedResult()
        {

        }

        public PaginatedResult(List<T> items, long totalCount)
        {
            Items = items;
            TotalCount = totalCount;
        }
        public List<T> Items { get; set; }
        public long TotalCount { get; set; }
    }
}
