namespace MovieApi.Interfaces
{
    public interface IWatchlistService
    {
        Task CheckIfMovieAlreadyInWatchlist(string userId, Guid movieId);
    }
}