using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos.GenreDto;
using MovieApi.Dtos.ReviewDto;

namespace MovieApi.Dtos.MovieDto
{
    public class MovieResponseDto
    {
        public int Id { get; set; } 
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public DateTime ReleasedOn { get; set;}
        public List<GenreForMovieResponseDto> Genres { get; set; } = new List<GenreForMovieResponseDto>();
        public List<ReviewForMovieResponseDto> Reviews { get; set; } = new List<ReviewForMovieResponseDto>();

    }
}