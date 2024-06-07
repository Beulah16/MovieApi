using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Exceptions;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class ReviewRepo(IMovieService movieService, MovieDbContext context) : IReviewRepo
    {
        private readonly MovieDbContext _context = context;
        private readonly IMovieService _movieService = movieService;

        public async Task<List<Review>?> GetMovieReviewAsync(Guid movieId)
        {
            await _movieService.CheckifMovieExists(movieId);

            var reviews = _context.Reviews.Where(r => r.MovieId.Equals(movieId));

            return await reviews.ToListAsync();
        }

        public async Task<Review?> PostMovieReviewAsync(Guid movieId, ReviewRequestDto reviewRequest)
        {
            await _movieService.CheckifMovieExists(movieId);

            var review = reviewRequest.ToReviewRequest(movieId);

            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review?> GetByIdAsync(Guid id)
        {
            return await GetReviewOrThrow(id);
        }

        public async Task<Review?> UpdateAsync(Guid id, ReviewRequestDto updateReview)
        {
            var review = await GetReviewOrThrow(id);

            review.Rating = updateReview.Rating;
            review.Comment = updateReview.Comment;
            review.UpdatedOn = DateTime.Now;
            await _context.SaveChangesAsync();

            return review;
        }

        public async Task<Review?> DeleteAsync(Guid id)
        {
            var review = await GetReviewOrThrow(id);

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private async Task<Review> GetReviewOrThrow(Guid reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId) ?? throw new ReviewNotFoundException("Review does not exist!");
        }
    }
}