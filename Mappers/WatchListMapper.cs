using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class WatchListMapper
    {
        public static Movie MapMovie(this WatchList watchList)
        {
            return new Movie
            {
                Id = watchList.Movie.Id,
                Title = watchList.Movie.Title,
                Description = watchList.Movie.Description,
            };
        }
    }
}