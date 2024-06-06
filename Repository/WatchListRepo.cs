using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class WatchListRepo(MovieDbContext context) : IWatchListRepo
    {
        private readonly MovieDbContext _context = context;
        public async Task<List<MovieResponse>?> GetWatchlistAsync(User user)
        {            
            return await _context.WatchLists.Where(u => u.UserId == user.Id)
            .Select(m => m.Movie.ToMovieResponse()).ToListAsync();
        }

        public async Task<WatchList> CreateAsync(User user, Guid movieId)
        {
           var watchlist = new WatchList
            {
                MovieId = movieId,
                UserId = user.Id,
            };
            await _context.WatchLists.AddAsync(watchlist);
            await _context.SaveChangesAsync();

            return watchlist;
        }

        public async Task<WatchList?> DeleteAsync(User user, Guid movieId)
        {
            var watchlist = await _context.WatchLists.FirstOrDefaultAsync(u => u.UserId == user.Id && u.MovieId == movieId);
            if (watchlist == null) return null;

            _context.WatchLists.Remove(watchlist);
            await _context.SaveChangesAsync();

            return watchlist;
        }
    }
}