using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;

namespace MovieApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController(IReviewRepository repo) : ControllerBase
    {
        private readonly IReviewRepository _repo = repo;

        [HttpGet("{reviewId}")]
        public async Task<IActionResult> GetById(Guid reviewId)
        {
            var review = await _repo.GetByIdAsync(reviewId);

            return Ok(review?.ToReviewResponse());
        }


        [HttpPut("{reviewId}")]
        public async Task<IActionResult> Update(Guid reviewId, ReviewRequest updateReview)
        {
            var review = await _repo.UpdateAsync(reviewId, updateReview);

            return Ok(review?.ToReviewResponse());
        }

        [HttpDelete("{reviewId}")]
        public async Task<IActionResult> Delete(Guid reviewId)
        {
            await _repo.DeleteAsync(reviewId);

            return Ok("Deleted");
        }

    }
}
