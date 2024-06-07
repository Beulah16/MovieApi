using MovieApi.Exceptions;
using MovieApi.Interfaces;

namespace MovieApi.Services
{
    public class MovieService(IMovieRepo movieRepo) : IMovieService
    {
        private readonly IMovieRepo _movieRepo = movieRepo;

        public async Task CheckifMovieExists(Guid movieId)
        {
            var movie = await _movieRepo.GetByIdAsync(movieId) ?? throw new MovieNotFoundException("Movie does not exist");
        }
    }
}