using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Interfaces;

namespace MyApp.Namespace
{
    [Route("api/genres")]
    [ApiController]
    public class GenreController(IGenreRepository genreRepo) : ControllerBase
    {
        private readonly IGenreRepository _genreRepo = genreRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _genreRepo.GetAllAsync());
        }

        [HttpGet("{genreId}")]
        public async Task<ActionResult<GenreResponse>> GetById(Guid genreId)
        {
            return Ok(await _genreRepo.GetByIdAsync(genreId));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenreRequest genreDto)
        {
            return Ok(await _genreRepo.PostAsync(genreDto));
        }

        [HttpPut("{genreId}")]
        public async Task<IActionResult> Update(Guid genreId, GenreRequest request)
        {
            return Ok(await _genreRepo.UpdateAsync(genreId, request));
        }

        [HttpDelete("{genreId}")]
        public async Task<IActionResult> Delete(Guid genreId)
        {
            await _genreRepo.DeleteAsync(genreId);

            return Ok("Deleted");
        }

    }
}
