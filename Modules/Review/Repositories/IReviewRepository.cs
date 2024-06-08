using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IReviewRepository
    {
        Task<Review?> PostMovieReviewAsync(Guid movieId, ReviewRequest newReview);
        Task<List<Review>?> GetMovieReviewAsync(Guid movieId);
        Task<Review?> GetByIdAsync(Guid id);
        Task<Review?> UpdateAsync(Guid id, ReviewRequest newReview);
        Task<Review?> DeleteAsync(Guid id);
    }
}