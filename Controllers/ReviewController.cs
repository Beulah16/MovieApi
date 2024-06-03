using System;
using System.Collections.Generic;

using System.Drawing.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
    public class ReviewController(IReviewRepo repo) : ControllerBase
    {
        private readonly IReviewRepo _repo = repo;
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var review = await _repo.GetByIdAsync(id);
            if (review == null) return NotFound("Review ndoes not exist");

            return Ok(review.ToReviewResponse());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, ReviewRequestDto updateReview)
        {
            var review = await _repo.UpdateAsync(id, updateReview);
            if (review == null) return NotFound("Review ndoes not exist");

            return Ok(review.ToReviewResponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var review = await _repo.DeleteAsync(id);
            if (review == null) return NotFound("Review does not exist");

            return Ok("Deleted");
        }

    }
}
