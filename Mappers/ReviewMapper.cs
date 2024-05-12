using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos;
using MovieApi.Dtos.ReviewDtos;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class ReviewMapper
    {
        public static Review CreateReview(this ReviewRequestDto review, int movieId)
        {
            return new Review
            {
                MovieId = movieId,
                Rating = review.Rating,
                Content = review.Content
            };
        }

        public static ReviewResponseDto ReadReview(this Review review)
        {
            return new ReviewResponseDto
            {
                Id = review.Id,
                MovieTitle = review.MovieTitle,
                Rating = review.Rating,
                Content = review.Content
            };
        }        
    }
}