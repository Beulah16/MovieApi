using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        List<Movie> Movies{ get; set; } = new List<Movie>();
    }
}