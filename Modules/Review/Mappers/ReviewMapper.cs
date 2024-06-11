using MovieApi.Dtos;
using MovieApi.Dtos.ReviewDtos;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class ReviewMapper
    {
        public static Review ToReviewRequest(this ReviewRequest review, Guid movieId)
        {
            return new Review
            {
                MovieId = movieId,
                Rating = review.Rating,
                Comment = review.Comment,
                CreatedOn = DateTime.Now,
            };
        }

        public static ReviewResponse ToReviewResponse(this Review review)
        {
            return new ReviewResponse
            {
                Id = review.Id,
                Rating = review.Rating,
                Comment = review.Comment
            };
        }
    }
}