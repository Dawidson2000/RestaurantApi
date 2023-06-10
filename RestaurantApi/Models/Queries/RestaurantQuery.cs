using RestaurantApi.Models.Enums;

namespace RestaurantApi.Models.Queries
{
    public class RestaurantQuery
    {
        public string SearchPhrase { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
        public string SortBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
