using MovieApi.Dtos;
using MovieApi.Dtos.ReviewDtos;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class ReviewMapper
    {
        public static Review ToReviewRequest(this ReviewRequestDto review, Guid movieId)
        {
            return new Review
            {
                MovieId = movieId,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedOn = DateTime.Now,
            };
        }

        public static ReviewResponseDto ToReviewResponse(this Review review)
        {
            return new ReviewResponseDto
            {
                Id = review.Id,
                // MovieTitle = review.MovieTitle,
                Rating = review.Rating,
                Comment = review.Comment
            };
        }        
    }
}