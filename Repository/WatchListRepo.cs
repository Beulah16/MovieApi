using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class WatchListRepo(MovieDbContext context) : IWatchListRepo
    {
        private readonly MovieDbContext _context = context;
        public async Task<List<Movie>?> GetWatchlistAsync(User user)
        {            
            return await _context.WatchLists.Where(u => u.UserId == user.Id)
            .Select(m => new Movie
            {
                Id = m.Movie.Id,
                Title = m.Movie.Title,
                Description = m.Movie.Description,
            }).ToListAsync();
        }

        public async Task<WatchList> CreateAsync(User user, int movieId)
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

        public async Task<WatchList?> DeleteAsync(User user, int movieId)
        {
            var watchlist = await _context.WatchLists.FirstOrDefaultAsync(u => u.UserId == user.Id && u.MovieId == movieId);
            if (watchlist == null) return null;

            _context.WatchLists.Remove(watchlist);
            await _context.SaveChangesAsync();

            return watchlist;
        }
    }
}