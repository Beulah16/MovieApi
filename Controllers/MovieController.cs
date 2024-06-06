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
    public class MovieController(IMovieRepo movieRepo, IReviewRepo reviewRepo, UserManager<User> user) : ControllerBase
    {
        private readonly IMovieRepo _movieRepo = movieRepo;
        private readonly IReviewRepo _reviewRepo = reviewRepo;
        private readonly UserManager<User> _user = user;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return NotFound("Register Or Login");

            var user = await _user.FindByIdAsync(userId);
            if (user == null) return NotFound("You're not a registered user!");

            var movies = await _movieRepo.GetAllAsync(query, user);

            return Ok(movies.Select(m => m.ToMovieResponse()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var movie = await _movieRepo.GetByIdAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok(movie.ToMovieResponse());
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
            var movie = await _movieRepo.UpdateAsync(id, updateMovie);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok(movie);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieRepo.DeleteAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok("Deleted!");
        }

        [Authorize]
        [HttpPatch("{id}/release")]
        public async Task<IActionResult> ReleaseMovie(Guid id)
        {
            var movie = await _movieRepo.ReleaseAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok(movie);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetMovieReview(Guid id)
        {
            var review = await _reviewRepo.GetMovieReviewAsync(id);
            if (review == null) return NotFound("Review does not exist");

            return Ok(review.Select(r => r.ToReviewResponse()));
        }

        // [Authorize]
        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> PostMovieReview(Guid id, ReviewRequestDto newReview)
        {
            var review = await _reviewRepo.PostMovieReviewAsync(id, newReview);
            if (review == null) return NotFound("Movie does not exist");

            return CreatedAtAction("GetMovieReview", new { id = review.Id }, review);
        }
    }
}
