using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class GenreRepo(MovieDbContext dbContext) : IGenreRepo
    {
        private readonly MovieDbContext _dbContext = dbContext;

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<GenreResponse?> GetByIdAsync(Guid Id)
        {
            var genre = await _dbContext.Genres.FindAsync(Id);
      
            return genre == null ? null : new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name,
                Movies = _dbContext.Movies.Where(x => x.Genre.Contains(genre.Name)).Select(m => m.ToMovieResponse()).ToList()
            };
        }

        public async Task<Genre> PostAsync(GenreRequest genreDto)
        {
            var genre = new Genre{Name = genreDto.Name};

            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            return genre;
        }

        public async Task<Genre?> UpdateAsync(Guid Id, GenreRequest genreDto)
        {
            var genre = await _dbContext.Genres.FindAsync(Id);
            if (genre == null) return null;

            genre.Name = genreDto.Name;
            await _dbContext.SaveChangesAsync();
            
            return genre;
        }

        public async Task<Genre?> DeleteAsync(Guid Id)
        {
            var genre = await _dbContext.Genres.FindAsync(Id);
            if (genre == null) return null;

            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();

            return genre;
        }
    }
}