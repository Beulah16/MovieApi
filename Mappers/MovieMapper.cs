using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class MovieMapper
    {
        public static Movie CreateMovie(this MovieRequestDto movieDto)
        {
            return new Movie
            {
                Title = movieDto.Title,
                Description = movieDto.Description,
                ReleasedOn = movieDto.ReleasedOn,
                Genre = movieDto.Genre
            };
        }

        public static MovieResponseDto ReadMovie(this Movie movie)
        {
            return new MovieResponseDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Description = movie.Description,
                ReleasedOn = movie.ReleasedOn,
                Genre = movie.Genre,
                Reviews = movie.Reviews.Select(r => r.ReadReview()).ToList()
            };
        }
    }
}