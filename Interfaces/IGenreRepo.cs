using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IGenreRepo
    {
        Task<Genre> PostAsync(GenreRequest genreDto);
        Task<List<Genre>> GetAllAsync();
        Task<GenreResponse?> GetByIdAsync(Guid Id);
        Task<Genre?> UpdateAsync(Guid Id, GenreRequest genreDto);
        Task<Genre?> DeleteAsync(Guid Id);




    }
}