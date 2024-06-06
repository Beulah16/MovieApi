using System.ComponentModel.DataAnnotations;

namespace MovieApi.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSubscribable { get; set; }
        [Url]
        public string CoverImage { get; set; } = string.Empty;
        [Url]
        public string Trailer { get; set;} = string.Empty;
        [Url]
        public string Url { get; set; } = string.Empty;
        public DateTime? ReleasedOn { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public List<Review> Reviews { get; set; } = [];
        public List<WatchList> Watchlist { get; set; } = [];

    }
}