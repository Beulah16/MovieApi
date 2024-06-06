using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IWatchListRepo
    {
        Task<List<MovieResponse>?> GetWatchlistAsync(User user);
        Task<WatchList> CreateAsync(User user, Guid movieId);
        Task<WatchList?> DeleteAsync(User user, Guid movieId);


    }
}