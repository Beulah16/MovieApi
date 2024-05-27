using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;

namespace MyApp.Namespace
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController(IGenreRepo genreRepo, MovieDbContext dbContext) : ControllerBase
    {
        private readonly IGenreRepo _genreRepo = genreRepo;
        private readonly MovieDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genre = await _genreRepo.GetAllAsync();
            return Ok(genre);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreResponse>> GetById(int id)
        {
            var genreDto = await _genreRepo.GetByIdAsync(id);
            if (genreDto == null) return NotFound("Genre does not exist");

            return Ok(genreDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenreRequest genreDto)
        {
            var genre = await _genreRepo.PostAsync(genreDto);

            return Ok(genre);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, GenreRequest genreDto)
        {
            var genre = await _genreRepo.UpdateAsync(id, genreDto);
            if (genre == null) return NotFound("Genre does not exist");

            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var genre = await _genreRepo.DeleteAsync(id);
            if (genre == null) return NotFound("Genre does not exist");

            return Ok("Deleted");
        }

    }
}
