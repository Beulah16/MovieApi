using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IWatchListRepo
    {
        Task<List<Movie>?> GetWatchlistAsync(User user);
        Task<WatchList> CreateAsync(User user, int movieId);
        Task<WatchList?> DeleteAsync(User user, int movieId);


    }
}