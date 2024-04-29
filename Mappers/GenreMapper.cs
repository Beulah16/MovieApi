using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Data;
using MovieApi.Dtos.GenreDto;
using MovieApi.Dtos.MovieDto;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class GenreMapper
    {
        public static Genre CreateGenre(this GenreRequestDto genreDto)
        {
            return new Genre
            {
                Type = genreDto.Type
            };
        }

         public static GenreResponseDto ReadGenre(this Genre genre)
        {
            return new GenreResponseDto
            {
                Id = genre.Id,
                Type = genre.Type,
                Movies = genre.Movies.Select(x => x.ReadMovieForGenre()).ToList()
            };
        }

          public static GenreForMovieResponseDto ReadGenreForMovie(this Genre genre)
        {
            return new GenreForMovieResponseDto
            {
                Type = genre.Type
            };
        }
    }
}