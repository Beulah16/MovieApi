using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/watchlist")]
    [ApiController]
    public class WatchListController : ControllerBase
    {
        private readonly UserManager<User> _user;
        private readonly IMovieRepo _movieRepo;
        private readonly IWatchListRepo _watchListRepo;
        private readonly MovieDbContext _dbContext;


        public WatchListController(UserManager<User> user, IMovieRepo movieRepo, IWatchListRepo watchListRepo, MovieDbContext dbContext)
        {
            _user = user;
            _movieRepo = movieRepo;
            _watchListRepo = watchListRepo;
            _dbContext = dbContext;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWatchList()
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            if (user == null) return BadRequest("You're not a registered user");

            var userWatchlist = await _watchListRepo.GetWatchlistAsync(user);

            return Ok(userWatchlist);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWatchList(Guid movieId)
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound("You're not a registered user");

            var movie = await _dbContext.Movies.FindAsync(movieId);
            if (movie == null) return NotFound("Movie does not exist");

            var userWatchlist = await _watchListRepo.GetWatchlistAsync(user);
            if (userWatchlist.Any(x => x.Id == movie.Id)) return BadRequest("Movie already exists in the watchlist");

            var watchlist = await _watchListRepo.CreateAsync(user, movie.Id);
            return Ok("Added to watchlist!");
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteWatchlist(Guid movieId)
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound("You're not a registered user");

            var userWatchlist = await _watchListRepo.GetWatchlistAsync(user);
            var movie = userWatchlist.FirstOrDefault(x => x.Id == movieId);
            if (movie == null) return NotFound("Movie does not exist in your watchlist");

            await _watchListRepo.DeleteAsync(user, movieId);
            return Ok("Removed from watchlist!");
        }
    }
}