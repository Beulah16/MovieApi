using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Data;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/watchlist")]
    [ApiController]
    public class WatchListController(UserManager<User> user, IWatchListRepo watchListRepo, MovieDbContext dbContext) : ControllerBase
    {
        private readonly UserManager<User> _user = user;
        private readonly IWatchListRepo _watchListRepo = watchListRepo;
        private readonly MovieDbContext _dbContext = dbContext;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWatchList()
        {
            if (GetUserId().IsNullOrEmpty()) return BadRequest("You're not a registered user");
            var userWatchlist = await _watchListRepo.GetWatchlistAsync(GetUserId());

            return Ok(userWatchlist);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWatchList(Guid movieId)
        {
            if (GetUserId().IsNullOrEmpty()) return BadRequest("You're not a registered user");

            var movie = await _dbContext.Movies.FindAsync(movieId);
            if (movie == null) return NotFound("Movie does not exist");

            var userWatchlist = await _watchListRepo.GetWatchlistAsync(GetUserId());
            if (userWatchlist?.Any(x => x.Id == movieId) == true) return BadRequest("Movie already exists in the watchlist");

            return Ok(await _watchListRepo.CreateAsync(GetUserId(), movieId));
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteWatchlist(Guid watchListId)
        {
            var deleted = await _watchListRepo.DeleteAsync(watchListId);
            if (deleted == null) return NotFound("Movie does not exist in your watchlist");

            return Ok("Removed from watchlist!");
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }
    }
}