using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewRepo _repo;
        public ReviewController(IReviewRepo repo)
        {
            _repo = repo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var review = await _repo.ReadByIdAsync(id);
            if (review == null) return NotFound("Review ndoes not exist");

            return Ok(review.ReadReview());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReviewRequestDto updateReview)
        {
            var review = await _repo.UpdateAsync(id, updateReview);
            if (review == null) return NotFound("Review ndoes not exist");

            return Ok(review.ReadReview());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _repo.DeleteAsync(id);
            if (review == null) return NotFound("Review does not exist");

            return Ok("Deleted");
        }

    }
}
