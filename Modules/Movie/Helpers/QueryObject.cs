namespace MovieApi.Helpers
{
    public class QueryObject
    {
        public string? Search { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDescending { get; set; } = false;
        public bool? IsReleased { get; set; }
    }

}