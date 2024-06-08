using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Exceptions;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class GenreRepository(MovieDbContext dbContext) : IGenreRepository
    {
        private readonly MovieDbContext _dbContext = dbContext;

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _dbContext.Genres.ToListAsync();
        }

        public async Task<GenreResponse?> GetByIdAsync(Guid genreId)
        {
            var genre = await GetGenreOrThrow(genreId);

            return new GenreResponse
            {
                Id = genre.Id,
                Name = genre.Name,
                Movies = _dbContext.Movies.Where(x => x.Genre.Contains(genre.Name)).Select(m => m.ToMovieResponse()).ToList()
            };
        }

        public async Task<Genre> PostAsync(GenreRequest request)
        {
            var genre = new Genre { Name = request.Name };

            await _dbContext.Genres.AddAsync(genre);
            await _dbContext.SaveChangesAsync();

            return genre;
        }

        public async Task<Genre?> UpdateAsync(Guid genreId, GenreRequest request)
        {
            var genre = await GetGenreOrThrow(genreId);

            genre.Name = request.Name;
            await _dbContext.SaveChangesAsync();

            return genre;
        }

        public async Task<Genre?> DeleteAsync(Guid genreId)
        {
            var genre = await GetGenreOrThrow(genreId);

            _dbContext.Genres.Remove(genre);
            await _dbContext.SaveChangesAsync();

            return genre;
        }

        private async Task<Genre> GetGenreOrThrow(Guid genreId)
        {
            return await _dbContext.Genres.FindAsync(genreId) ?? throw new GenreNotFoundException("Genre does not exist!");
        }
    }
}