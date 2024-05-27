using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class GenreRepo : IGenreRepo
    {
        private readonly MovieDbContext _dbContext;

        public GenreRepo(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<Genre>> GetAllAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<GenreResponse?> GetByIdAsync(int Id)
        {
            var genre = await _dbContext.Genres.FindAsync(Id);
            if (genre == null) return null;

            return new GenreResponse
            {
                Id = genre.Id,
                Type = genre.Type,
                Movies = _dbContext.Movies.Where(x => x.Genre.Contains(genre.Type)).ToList()
            };
        }

        public async Task<Genre> PostAsync(GenreRequest genreDto)
        {
            var genre = genreDto.CreateGenre();
            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            return genre;
        }

        public async Task<Genre?> UpdateAsync(int Id, GenreRequest genreDto)
        {
            var genre = await _dbContext.Genres.FindAsync(Id);
            if (genre == null) return null;
            genre.Type = genreDto.Type;

            await _dbContext.SaveChangesAsync();
            return genre;
        }

        public async Task<Genre?> DeleteAsync(int Id)
        {
            var genre = await _dbContext.Genres.FindAsync(Id);
            if (genre == null) return null;

            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();

            return genre;
        }
    }
}