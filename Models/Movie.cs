using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public DateTime ReleasedOn { get; set;}
        public int GenreId { get; set; }
        public Genre? MovieGenre { get; set; }
        List<Review> Reviews { get; set; } = new List<Review>();
    }
}