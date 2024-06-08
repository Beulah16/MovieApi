using MovieApi.Exceptions;
using MovieApi.Interfaces;

namespace MovieApi.Services
{
    public class MovieService(IMovieRepository movieRepo) : IMovieService
    {
        private readonly IMovieRepository _movieRepo = movieRepo;

        public async Task CheckifMovieExists(Guid movieId)
        {
            var movie = await _movieRepo.GetByIdAsync(movieId) ?? throw new MovieNotFoundException("Movie does not exist");
        }
    }
}