using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos.GenreDto;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("/api/genre")]
    public class GenreController(MovieDbContext dbContext) : ControllerBase
    {
        private readonly MovieDbContext _dbContext = dbContext;
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _dbContext.Genres.ToListAsync();

            return Ok(genres);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GenreRequestDto genreDto)
        {
            var genres = await _dbContext.Genres.AddAsync(genreDto.CreateGenre());
            await _dbContext.SaveChangesAsync();

            return Ok(genreDto);
        }
    }
}