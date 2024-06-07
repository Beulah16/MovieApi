using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos;
using MovieApi.Exceptions;
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

            movie = query.IsReleased.HasValue ? (
                query.IsReleased.Value
                ? movie.Where(m => m.ReleasedOn != null)
                : movie.Where(m => m.ReleasedOn == null)
            ) : movie;

            if (!user.HasSubscribed)
                return await movie.Where(m => m.IsSubscribable == false).ToListAsync();
            else
                return await movie.ToListAsync();
        }

        public async Task<Movie?> GetByIdAsync(Guid movieId)
        {
            var movie = await _dbContext.Movies.Include(movie => movie.Reviews)
                .FirstOrDefaultAsync(movie => movie.Id == movieId);

            return movie ?? throw new MovieNotFoundException("Movie does not exist!");
        }

        public async Task<Movie> PostAsync(MovieRequest request)
        {
            var movie = request.ToMovieRequest();

            await _dbContext.Movies.AddAsync(movie);
            await _dbContext.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie?> UpdateAsync(Guid id, MovieRequest request)
        {
            var movie = await GetByIdAsync(id);

            if (movie != null)
            {
                UpdateMovie(movie, request);
                await _dbContext.SaveChangesAsync();
            }

            return movie;
        }

        public async Task<Movie?> DeleteAsync(Guid id)
        {
            var movie = await GetByIdAsync(id);

            if (movie != null)
            {
                _dbContext.Movies.Remove(movie);
                await _dbContext.SaveChangesAsync();
            }

            return movie;
        }

        public async Task<Movie?> ReleaseAsync(Guid id)
        {
            var movie = await GetByIdAsync(id);

            if (movie != null)
            {
                movie.ReleasedOn = DateTime.Now;
                movie.UpdatedOn = DateTime.Now;
                await _dbContext.SaveChangesAsync();
            }

            return movie;
        }

        private static void UpdateMovie(Movie movie, MovieRequest request)
        {
            movie.Title = request.Title;
            movie.CoverImage = request.CoverImage;
            movie.Url = request.Url;
            movie.Genre = request.Genre;
            movie.Description = request.Description;
            movie.UpdatedOn = DateTime.Now.AddDays(1);
        }
    }
}