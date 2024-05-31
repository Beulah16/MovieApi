using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieRepo _movieRepo;
        private readonly IReviewRepo _reviewRepo;
        private readonly UserManager<User> _user;
        public MovieController(IMovieRepo movieRepo, IReviewRepo reviewRepo, UserManager<User> user)
        {
            _movieRepo = movieRepo;
            _reviewRepo = reviewRepo;
            _user = user;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var movies = await _movieRepo.GetAllAsync(query);

            return Ok(movies.Select(m => m.ReadMovie()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var movie = await _movieRepo.GetByIdAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");


            return Ok(movie.ReadMovie());
        }

        // [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieRequestDto newMovie)
        {
            var movie = await _movieRepo.PostAsync(newMovie);

            return CreatedAtAction(nameof(GetById), new { id = movie.Id }, movie);
        }

        // [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] MovieRequestDto updateMovie)
        {
            var movie = await _movieRepo.UpdateAsync(id, updateMovie);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok(movie);
        }

        // [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var movie = await _movieRepo.DeleteAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok("Deleted!");
        }

        // [Authorize]
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

            return Ok(review.Select(r => r.ReadReview()));
        }

        // [Authorize]
        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> PostMovieReview(Guid id, ReviewRequestDto newReview)
        {
            var review = await _reviewRepo.PostMovieReviewAsync(id, newReview);
            if (review == null) return NotFound("Movie does not exist");

            return CreatedAtAction("ReadMovieReview", new { id = review.Id }, review);
        }
    }
}
