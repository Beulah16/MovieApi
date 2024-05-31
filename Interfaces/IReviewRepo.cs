using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IReviewRepo
    {
        Task<Review?> PostMovieReviewAsync(Guid movieId, ReviewRequestDto newReview);
        Task<List<Review>?> GetMovieReviewAsync(Guid movieId);
        Task<Review?> GetByIdAsync(Guid id);
        Task<Review?> UpdateAsync(Guid id, ReviewRequestDto newReview);
        Task<Review?> DeleteAsync(Guid id);
    }
}