namespace MovieApi.Dtos
{
    public class WatchListResponse
    {
        public Guid Id { get; set; }
        public MovieResponse? Movie { get; set; }
    }
}