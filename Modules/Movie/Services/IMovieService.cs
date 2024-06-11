namespace MovieApi.Interfaces
{
    public interface IMovieService
    {
        Task CheckifMovieExists(Guid movieId);
    }
}