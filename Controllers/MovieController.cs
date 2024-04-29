using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using MovieApi.Data;
using MovieApi.Dtos.MovieDto;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("/api/movies")]
    [ApiController]
    public class MovieController(MovieDbContext dbContext) : ControllerBase
    {
        private readonly MovieDbContext _dbContext = dbContext;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var movies = await _dbContext.Movies.ToListAsync();

            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MovieRequestDto movieDto)
        {
            await _dbContext.Movies.AddAsync(movieDto.CreateMovie());
            await _dbContext.SaveChangesAsync();

            return Ok(movieDto);
        }
        
    }
}