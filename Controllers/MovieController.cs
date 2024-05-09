using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;
using MovieApi.Repository;

namespace MovieApi.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController(IMovieRepo repo) : ControllerBase
    {
        private readonly IMovieRepo _repo = repo;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MovieRequestDto newMovie)
        {
            var movie = await _repo.CreateAsync(newMovie);

            return Ok(movie);

            // return CreatedAtAction(nameof(ReadById),; new { id = movie.Id }, movie);
        }

        [HttpGet]
        public async Task<IActionResult> ReadAll([FromQuery] QueryObject query)
        {
            var movies = await _repo.ReadAllAsync(query);

            return Ok(movies.Select(m => m.ReadMovie()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ReadById(int id)
        {
            var movie = await _repo.ReadByIdAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");


            return Ok(movie.ReadMovie());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MovieRequestDto updateMovie)
        {
            var movie = await _repo.UpdateAsync(id, updateMovie);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok(movie);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var movie = await _repo.DeleteAsync(id);
            if (movie == null) return NotFound("Movie does not exist!");

            return Ok("Deleted!");
        }
    }
}
