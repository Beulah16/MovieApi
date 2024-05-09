using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class MovieRepo(MovieDbContext dbContext) : IMovieRepo
    {
        private readonly MovieDbContext _dbContext = dbContext;
        public async Task<Movie> CreateAsync(MovieRequestDto newMovie)
        {
            var movie = newMovie.CreateMovie();
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<List<Movie>> ReadAllAsync(QueryObject query)
        {
            var movie = _dbContext.Movies.Include(r => r.Reviews).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                movie = movie.Where(m => m.Title.Contains(query.Title));
            }
            if (!string.IsNullOrWhiteSpace(query.Genre))
            {
                movie = movie.Where(m => m.Genre.Contains(query.Genre));
            }
            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    movie = query.IsDescending ? movie.OrderByDescending(m => m.Title) : movie.OrderBy(m => m.Title);
                }
                if (query.SortBy.Equals("ReleasedOn", StringComparison.OrdinalIgnoreCase))
                {
                    movie = query.IsDescending ? movie.OrderByDescending(m => m.ReleasedOn) : movie.OrderBy(m => m.ReleasedOn);
                }
            }

            return await movie.ToListAsync();
        }

        public async Task<Movie?> ReadByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.Include(c => c.Reviews).FirstOrDefaultAsync(x => id == x.Id);
            if (movie == null) return null;

            return movie;
        }

        public async Task<Movie?> UpdateAsync(int id, MovieRequestDto updateMovie)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) return null;

            movie.Title = updateMovie.Title;
            movie.Description = updateMovie.Description;
            movie.Genre = updateMovie.Genre;

            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> DeleteAsync(int id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) return null;

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return movie;
        }
    }
}