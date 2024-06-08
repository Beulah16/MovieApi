using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieReviewsController(IReviewRepository reviewRepo) : ControllerBase
    {
        private readonly IReviewRepository _reviewRepo = reviewRepo;

        [HttpGet("{movieId}/reviews")]
        public async Task<IActionResult> GetMovieReview(Guid movieId)
        {
            var review = await _reviewRepo.GetMovieReviewAsync(movieId);

            return Ok(review?.Select(r => r.ToReviewResponse()));
        }

        // [Authorize]
        [HttpPost("{movieId}/reviews")]
        public async Task<IActionResult> PostMovieReview(Guid movieId, ReviewRequest newReview)
        {
            var review = await _reviewRepo.PostMovieReviewAsync(movieId, newReview);

            return CreatedAtAction("GetMovieReview", new { id = review?.Id }, review);
        }
    }
}
