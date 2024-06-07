using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Interfaces;

namespace MovieApi.Controllers
{
    [Route("api/watchlist")]
    [ApiController]
    public class WatchListController(
        IWatchListRepo watchListRepo,
        IAuthService authService,
        IWatchlistService watchlistService,
        IMovieService movieService
        ) : ControllerBase
    {
        private readonly IWatchListRepo _watchListRepo = watchListRepo;
        private readonly IAuthService _authService = authService;
        private readonly IWatchlistService _watchlistService = watchlistService;
        private readonly IMovieService _movieService = movieService;

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetWatchList()
        {
            _authService.CheckIfAuthenticated(User);
            var userId = _authService.GetUserId(User);

            return Ok(await _watchListRepo.GetWatchlistAsync(userId));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateWatchList(Guid movieId)
        {
            _authService.CheckIfAuthenticated(User);
            var userId = _authService.GetUserId(User);

            await _movieService.CheckifMovieExists(movieId);
            await _watchlistService.CheckIfMovieAlreadyInWatchlist(userId, movieId);

            return Ok(await _watchListRepo.CreateAsync(userId, movieId));
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteWatchlist(Guid watchListId)
        {
            await _watchListRepo.DeleteAsync(watchListId);

            return Ok("Removed from watchlist!");
        }
    }
}