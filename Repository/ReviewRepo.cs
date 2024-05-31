using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class ReviewRepo(MovieDbContext context) : IReviewRepo
    {
        private readonly MovieDbContext _context = context;

        public async Task<List<Review>?> GetMovieReviewAsync(Guid movieId)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null) return null;

            var reviews = _context.Reviews.Where(r => r.MovieId.Equals(movieId));

            return await reviews.ToListAsync();
        }

        public async Task<Review?> PostMovieReviewAsync(Guid movieId, ReviewRequestDto newReview)
        {
            var movie = await _context.Movies.FindAsync(movieId);
            if (movie == null) return null;

            var review = newReview.CreateReview(movieId);
            review.MovieTitle = movie.Title;
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review?> GetByIdAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return null;

            return review;
        }

        public async Task<Review?> UpdateAsync(Guid id, ReviewRequestDto updateReview)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return null;

            review.Rating = updateReview.Rating;
            review.Content = updateReview.Content;
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review?> DeleteAsync(Guid id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return null;

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }
    }
}