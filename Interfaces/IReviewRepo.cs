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
        Task<Review?> CreateMovieReviewAsync(int movieId, ReviewRequestDto newReview);
        Task<List<Review>?> ReadMovieReviewAsync(int movieId);
        Task<Review?> ReadByIdAsync(int id);
        Task<Review?> UpdateAsync(int id, ReviewRequestDto newReview);
        Task<Review?> DeleteAsync(int id);
    }
}