using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Data;

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