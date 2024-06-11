using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetAllAsync(QueryObject query, User user);
        Task<Movie> PostAsync(MovieRequest newMovie);
        Task<Movie?> GetByIdAsync(Guid id);
        Task<Movie?> UpdateAsync(Guid id, MovieRequest newMovie);
        Task<Movie?> DeleteAsync(Guid id);
        Task<Movie?> ReleaseAsync(Guid id);
    }
}