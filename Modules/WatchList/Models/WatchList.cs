namespace MovieApi.Models
{
    public class WatchList
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public Guid MovieId { get; set; }
        public User? User { get; set; }
        public Movie? Movie { get; set; }
    }
}