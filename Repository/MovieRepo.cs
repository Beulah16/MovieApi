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


        public async Task<List<Movie>> GetAllAsync(QueryObject query, User user)
        {
            var movie = _dbContext.Movies.AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                movie = movie.Where(m =>
                        m.Title.Contains(query.Search)
                        || m.Description.Contains(query.Search)
                        || m.Genre.Contains(query.Search)
                        || m.Reviews.Any(r => r.Rating.ToString().Contains(query.Search))
                        || m.ReleasedOn.HasValue && m.ReleasedOn.Value.ToString().Contains(query.Search));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                {
                    movie = query.IsDescending ? movie.OrderByDescending(m => m.Title) : movie.OrderBy(m => m.Title);
                }
            }
            movie = query.IsReleased.HasValue ? (query.IsReleased.Value ? movie.Where(m => m.ReleasedOn != null) : movie.Where(m => m.ReleasedOn == null)) : movie;

            if(user.HasSubscribed == false)
                return await movie.Where(m => m.IsSubscribable == false).ToListAsync();
            else
                return await movie.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(Guid id)
        {
            var movie = await _dbContext.Movies.Include(r => r.Reviews).FirstOrDefaultAsync(x => x.Id == id);
            if (movie == null) return null;

            return movie;
        }

        public async Task<Movie> PostAsync(MovieRequest newMovie)
        {
            var movie = newMovie.ToMovieRequest();
            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();
            return movie;
        }
        public async Task<Movie?> UpdateAsync(Guid id, MovieRequest updateMovie)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) return null;

            movie.Title = updateMovie.Title;
            movie.CoverImage = updateMovie.CoverImage;
            movie.Url = updateMovie.Url;
            movie.Genre = updateMovie.Genre;
            movie.Description = updateMovie.Description;
            movie.UpdatedOn = DateTime.Now.AddDays(1);
            await _dbContext.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie?> DeleteAsync(Guid id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) return null;

            _dbContext.Movies.Remove(movie);
            await _dbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie?> ReleaseAsync(Guid id)
        {
            var movie = await _dbContext.Movies.FindAsync(id);
            if (movie == null) return null;

            movie.ReleasedOn = DateTime.Now.AddMonths(2);
            movie.UpdatedOn = DateTime.Now.AddMonths(2);
            await _dbContext.SaveChangesAsync();
            return movie;
        }
    }
}