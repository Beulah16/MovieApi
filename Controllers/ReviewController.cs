using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/reviews")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public ReviewController(MovieDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReviewRequestDto newReview)
        {
            var movie = await _context.Movies.FindAsync(newReview.MovieId);
            if (movie == null) return BadRequest("Movie does not exist");

            var review = newReview.CreateReview();
            review.MovieTitle = movie.Title;
            await _context.Reviews.AddAsync(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("ReadById", new { id = review.Id }, review);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var review = await _context.Reviews.ToListAsync();
            return Ok(review);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound("Review does not exist");

            return Ok(review);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ReviewRequestDto updateReview)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound("Review does not exist");
            
            var movie = await _context.Movies.FindAsync(updateReview.MovieId);
            if (movie == null) return BadRequest("Movie does not exist");

            review.MovieId = updateReview.MovieId;
            review.MovieTitle = movie.Title;
            review.Rating = updateReview.Rating;
            review.Content = updateReview.Content;
            await _context.SaveChangesAsync();

            return Ok(review);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _context.Reviews.FindAsync(id);
            if (review == null) return NotFound("Review does not exist");

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return Ok("Deletd");
        }
        
    }
}
