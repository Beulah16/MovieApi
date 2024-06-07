using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController(IMovieRepo movieRepo, IReviewRepo reviewRepo, IMovieService movieService, IAuthService authService) : ControllerBase
    {
        private readonly IMovieRepo _movieRepo = movieRepo;
        private readonly IReviewRepo _reviewRepo = reviewRepo;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var movie = await _movieRepo.GetByIdAsync(id);

            return Ok(movie?.ToMovieResponse());
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieRequest request)
        {
            var movie = await _movieRepo.PostAsync(request);

            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MovieRequest updateMovie)
        {
            return Ok(await _movieRepo.UpdateAsync(id, updateMovie));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _movieRepo.DeleteAsync(id);
            return Ok("Deleted!");
        }

        [Authorize]
        [HttpPatch("{id}/release")]
        public async Task<IActionResult> ReleaseMovie(Guid id)
        {
            return Ok(await _movieRepo.ReleaseAsync(id));
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetMovieReview(Guid id)
        {
            var review = await _reviewRepo.GetMovieReviewAsync(id);

            return Ok(review?.Select(r => r.ToReviewResponse()));
        }

        // [Authorize]
        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> PostMovieReview(Guid id, ReviewRequestDto newReview)
        {
            var review = await _reviewRepo.PostMovieReviewAsync(id, newReview);

            return CreatedAtAction("GetMovieReview", new { id = review?.Id }, review);
        }
    }
}
