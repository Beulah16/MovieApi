using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Exceptions;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class WatchListRepo(MovieDbContext context) : IWatchListRepo
    {
        private readonly MovieDbContext _context = context;
        public async Task<List<WatchListResponse>?> GetWatchlistAsync(string userId)
        {
            return await _context.WatchLists.Where(watchList => watchList.UserId == userId)
            .Select(watchList => new WatchListResponse
            {
                Id = watchList.Id,
                Movie = watchList.Movie != null ? watchList.Movie.ToMovieResponse() : null,
            }).ToListAsync();
        }

        public async Task<WatchList> CreateAsync(string userId, Guid movieId)
        {
            var watchlist = new WatchList
            {
                MovieId = movieId,
                UserId = userId,
            };
            await _context.WatchLists.AddAsync(watchlist);
            await _context.SaveChangesAsync();

            return watchlist;
        }

        public async Task<WatchList?> GetWatchListByIdAsync(Guid watchListId)
        {
            return await _context.WatchLists.FindAsync(watchListId);
        }


        public async Task<WatchList?> DeleteAsync(Guid watchListId)
        {
            var watchlist = await GetWatchListByIdAsync(watchListId) ?? throw new MovieNotFoundException("Movie does not exist in your watchlist");

            _context.WatchLists.Remove(watchlist);
            await _context.SaveChangesAsync();

            return watchlist;
        }

        public async Task<bool> InWatchList(string userId, Guid movieId)
        {
            var watchList = await _context.WatchLists.Where(
                watchList => watchList.UserId.Equals(userId)
                && watchList.MovieId.Equals(movieId)
            ).FirstAsync();

            return watchList != null;
        }
    }
}