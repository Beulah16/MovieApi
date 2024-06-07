using MovieApi.Exceptions;
using MovieApi.Interfaces;

namespace MovieApi.Services
{
    public class WatchlistService(IWatchListRepo watchListRepo) : IWatchlistService
    {
        private readonly IWatchListRepo _watchListRepo = watchListRepo;

        public async Task CheckIfMovieAlreadyInWatchlist(string userId, Guid movieId)
        {
            if (await _watchListRepo.InWatchList(userId, movieId))
                throw new MovieAlreadyInWatchlistException("Movie already exists in your watchlist");
        }
    }
}