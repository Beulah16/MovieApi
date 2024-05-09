using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos;
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

        public static ReviewRequestDto ReadReview(this Review review)
        {
            return new ReviewRequestDto
            {
                MovieId = review.MovieId,
                Rating = review.Rating,
                Content = review.Content

            };
        }
    }
}