using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Interfaces;
using MovieApi.Mappers;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController(IMovieRepo movieRepo, IReviewRepo reviewRepo) : ControllerBase
    {
        private readonly IMovieRepo _movieRepo = movieRepo;
        private readonly IReviewRepo _reviewRepo = reviewRepo;

        // [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieRequestDto newMovie)
        {
            var movie = await _movieRepo.CreateAsync(newMovie);

            return CreatedAtAction(nameof(ReadById), new { id = movie.Id }, movie);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll([FromQuery] QueryObject query)
        {
            var movies = await _movieRepo.ReadAllAsync(query);

            return Ok(movies.Select(m => m.ReadMovie()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var movie = await _movieRepo.ReadByIdAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");


            return Ok(movie.ReadMovie());
        }

        // [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovieRequestDto updateMovie)
        {
            var movie = await _movieRepo.UpdateAsync(id, updateMovie);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok(movie);
        }

        // [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _movieRepo.DeleteAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok("Deleted!");
        }

        // [Authorize]
        [HttpPatch("{id}/release")]
        public async Task<IActionResult> ReleaseMovie(int id)
        {
            var movie = await _movieRepo.ReleaseAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok(movie);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> ReadMovieReview(int id)
        {
            var review = await _reviewRepo.ReadMovieReviewAsync(id);
            if (review == null) return NotFound("Review does not exist");

            return Ok(review.Select(r => r.ReadReview()));
        }

        // [Authorize]
        [HttpPost("{id}/reviews")]
        public async Task<IActionResult> CreateMovieReview(int id, ReviewRequestDto newReview)
        {
            var review = await _reviewRepo.CreateMovieReviewAsync(id, newReview);
            if (review == null) return NotFound("Movie does not exist");

            return CreatedAtAction("ReadMovieReview", new { id = review.Id }, review);
        }
    }
}
