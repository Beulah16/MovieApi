using MovieApi.Dtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IWatchListRepo
    {
        Task<List<WatchListResponse>?> GetWatchlistAsync(string userId);
        Task<WatchList?> GetWatchListByIdAsync(Guid id);
        Task<bool> InWatchList(string userId, Guid movieId);
        Task<WatchList> CreateAsync(string userId, Guid movieId);
        Task<WatchList?> DeleteAsync(Guid watchListId);


    }
}