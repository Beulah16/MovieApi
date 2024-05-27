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
        Task<Review?> PostMovieReviewAsync(int movieId, ReviewRequestDto newReview);
        Task<List<Review>?> GetMovieReviewAsync(int movieId);
        Task<Review?> GetByIdAsync(int id);
        Task<Review?> UpdateAsync(int id, ReviewRequestDto newReview);
        Task<Review?> DeleteAsync(int id);
    }
}