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
                Genre = movieRequest.Genre,
                Description = movieRequest.Description,
                IsSubscribable = movieRequest.IsSubscribable,
                CoverImage = movieRequest.CoverImage.Trim(),
                Url = movieRequest.Url.Trim(),
                CreatedOn = DateTime.Now,
            };
        }

        public static MovieResponse ToMovieResponse(this Movie movie)
        {
            return new MovieResponse
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Description = movie.Description,
                IsSubscribable = movie.IsSubscribable,
                CoverImage = movie.CoverImage,
                Url = movie.Url,
                Trailer = movie.Trailer,
                ReleasedOn = movie.ReleasedOn?.ToString(),
                CreatedOn = movie.CreatedOn?.ToString(),
                Reviews = movie.Reviews.Select(r => r.ToReviewResponse()).ToList(),
            };
        }
    }
}