using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Data;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class GenreMapper
    {
        public static Genre CreateGenre(this GenreRequest genreDto)
        {
            return new Genre
            {
                Type = genreDto.Type,
            };
        }
    }
}