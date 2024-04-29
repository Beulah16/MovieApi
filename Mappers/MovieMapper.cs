using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos.MovieDto;
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
                Genres = movieDto.Genres.Select(x => x.CreateGenre()).ToList()
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
                Genres = movie.Genres.Select(g => g.ReadGenreForMovie()).ToList(),
                Reviews = movie.Reviews.Select(r => r.ReadReviewForMovie()).ToList()

            };
        }

        public static MovieForGenreResponseDto ReadMovieForGenre(this Movie movieDto)
        {
            return new MovieForGenreResponseDto
            {
                Title = movieDto.Title
            };
        }
    }
}