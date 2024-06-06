using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController(IGenreRepo genreRepo) : ControllerBase
    {
        private readonly IGenreRepo _genreRepo = genreRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genreRepo.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GenreResponse>> GetById(Guid id)
        {
            var genreDto = await _genreRepo.GetByIdAsync(id);
            if (genreDto == null) return NotFound("Genre does not exist");

            return Ok(genreDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenreRequest genreDto)
        {
            return Ok(await _genreRepo.PostAsync(genreDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, GenreRequest genreDto)
        {
            var genre = await _genreRepo.UpdateAsync(id, genreDto);
            if (genre == null) return NotFound("Genre does not exist");

            return Ok(genre);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var genre = await _genreRepo.DeleteAsync(id);
            if (genre == null) return NotFound("Genre does not exist");

            return Ok("Deleted");
        }

    }
}
