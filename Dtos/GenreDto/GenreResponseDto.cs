using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos.MovieDto;

namespace MovieApi.Dtos.GenreDto
{
    public  class GenreResponseDto
    {
        public int Id { get; set; }
        public string Type { get; set; } = string.Empty;
        public List<MovieForGenreResponseDto> Movies{ get; set; } = new List<MovieForGenreResponseDto>();
    }
}