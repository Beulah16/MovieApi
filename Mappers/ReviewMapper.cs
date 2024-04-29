using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos.ReviewDto;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class ReviewMapper
    {
        public static Review CreateReview(this ReviewRequestDto reviewDto)
        {
            return new Review
            {
                MovieId = reviewDto.MovieId,
                Rating = reviewDto.Rating,
                Content = reviewDto.Content
            };
        }

        public static ReviewResponseDto ReadReview(this Review review)
        {
            return new ReviewResponseDto
            {
                Id = review.Id,
                Rating = review.Rating,
                Content = review.Content,
                MovieId = review.MovieId
            };
        }

        public static ReviewForMovieResponseDto ReadReviewForMovie(this Review review)
        {
            return new ReviewForMovieResponseDto
            {
                Rating = review.Rating,
                Content = review.Content,
            };
        }
    }
}