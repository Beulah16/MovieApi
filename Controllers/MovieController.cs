using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController(MovieDbContext dbContext) : ControllerBase
    {
        private readonly MovieDbContext _dbContext = dbContext;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieRequestDto newMovie)
        {
            var movie = newMovie.CreateMovie();
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(ReadById), new { id = movie.Id }, movie);
        }

        
        [HttpGet]
        public async Task<IActionResult> ReadAll()
        {
            var movie = await _dbContext.Movies.Include(r => r.Reviews)
                .Select(m => m.ReadMovie()).ToListAsync();

            return Ok(movie);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var movie = await _dbContext.Movies.Include(c => c.Reviews).FirstOrDefaultAsync(x => id == x.Id);
            if (movie == null) return NotFound("Movie does not exist");

            return Ok(movie.ReadMovie());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovieRequestDto updateMovie)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) return NotFound("Movie does not exist");

            movie.Title = updateMovie.Title;
            movie.Description = updateMovie.Description;
            movie.ReleasedOn = updateMovie.ReleasedOn;
            movie.Genre = updateMovie.Genre;

            await _dbContext.SaveChangesAsync();
            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) return NotFound("Movie does not exist");

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return Ok("Deleted");
        }
    }
}
