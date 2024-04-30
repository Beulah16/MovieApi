using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace MovieApi.Models
{
    public class Movie
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty; 
        public TimeSpan Duration { get; set; } = new TimeSpan();
        public string Description { get; set; } = string.Empty ;
        public DateTime ReleasedOn { get; set;}
        public List<string> Genre { get; set; } = new List<string>();
        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}