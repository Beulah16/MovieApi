using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToMovieRequest(this MovieRequest movieRequest)
        {
            return new Movie
            {
                Title = movieRequest.Title.Trim(),
                Description = movieRequest.Description,
                Genre = movieRequest.Genre,
                CreatedOn = DateTime.Now,
            };
        }

        public static MovieResponse ToMovieResponse(this Movie movie)
        {
            return new MovieResponse
            {
                Id = movie.Id,
                CoverImage = movie.CoverImage,
                Title = movie.Title,
                Url = movie.Url,
                Genre = movie.Genre,
                Description = movie.Description,
                ReleasedOn = movie.ReleasedOn.ToString().IsNullOrEmpty() ?  null : movie.ReleasedOn.ToString(),
                Reviews = movie.Reviews.Select(r => r.ToReviewResponse()).ToList(),
            };
        }
    }
}