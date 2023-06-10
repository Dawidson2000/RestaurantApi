namespace RestaurantApi.Models.Queries
{
    public class PagedResult<T>
    {
        public IReadOnlyCollection<T> Items { get; set; }
        public int TotalPages { get; set; }
        public int ItemsFrom { get; set; }
        public int ItemsTo { get; set;}
        public int TotalItemsCount { get; set; }

        public PagedResult(IReadOnlyCollection<T> items, int totalItemsCount, int pageNumber, int pageSize) 
        {
            Items = items;
            TotalItemsCount = totalItemsCount;
            ItemsFrom = pageNumber * (pageSize - 1) + 1;
            ItemsTo = pageSize * pageNumber;
            TotalPages = (int)Math.Ceiling((totalItemsCount / (double)pageSize));
        }
    }
}
