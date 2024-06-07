using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IGenreRepo
    {
        Task<Genre> PostAsync(GenreRequest request);
        Task<List<Genre>> GetAllAsync();
        Task<GenreResponse?> GetByIdAsync(Guid Id);
        Task<Genre?> UpdateAsync(Guid Id, GenreRequest request);
        Task<Genre?> DeleteAsync(Guid Id);




    }
}