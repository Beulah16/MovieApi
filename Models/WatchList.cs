namespace MovieApi.Models
{
    public class WatchList
    {
        public string UserId { get; set;}
        public Guid MovieId { get; set;}
        public User User { get; set; }
        public Movie Movie { get; set; }
    }
}