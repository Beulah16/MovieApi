using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Interfaces;
using MovieApi.Mappers;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController(IMovieRepository movieRepo, IReviewRepository reviewRepo, IMovieService movieService, IAuthService authService) : ControllerBase
    {
        private readonly IMovieRepository _movieRepo = movieRepo;
        private readonly IReviewRepository _reviewRepo = reviewRepo;
        private readonly IMovieService _movieService = movieService;
        private readonly IAuthService _authService = authService;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            _authService.CheckIfAuthenticated(User);
            var userId = _authService.GetUserId(User);
            var user = await _authService.GetUserData(userId);

            var movies = await _movieRepo.GetAllAsync(query, user);

            return Ok(movies.Select(m => m.ToMovieResponse()));
        }

        [HttpGet("{movieId}")]
        public async Task<IActionResult> GetById(Guid movieId)
        {
            var movie = await _movieRepo.GetByIdAsync(movieId);

            return Ok(movie?.ToMovieResponse());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieRequest request)
        {
            var movie = await _movieRepo.PostAsync(request);

            return CreatedAtAction(nameof(GetById), new { userId = movie.Id }, movie);
        }

        [Authorize]
        [HttpPut("{movieId}")]
        public async Task<IActionResult> Update(Guid movieId, [FromBody] MovieRequest updateMovie)
        {
            return Ok(await _movieRepo.UpdateAsync(movieId, updateMovie));
        }

        [Authorize]
        [HttpDelete("{movieId}")]
        public async Task<IActionResult> Delete(Guid movieId)
        {
            await _movieRepo.DeleteAsync(movieId);
            return Ok("Deleted!");
        }

        [Authorize]
        [HttpPatch("{movieId}/release")]
        public async Task<IActionResult> ReleaseMovie(Guid movieId)
        {
            return Ok(await _movieRepo.ReleaseAsync(movieId));
        }
    }
}
