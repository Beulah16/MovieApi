using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Models;

namespace MovieApi.Dtos.MovieDtos
{
    public class GenreResponse
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public List<Movie> Movies { get; set; } = [];
    }
}