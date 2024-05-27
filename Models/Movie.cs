using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime? ReleasedOn { get; set; }
        public DateTime? CreatedOn { get; }
        public DateTime? UpdatedOn { get; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<WatchList> Watchlist { get; set; } = [];

    }
}