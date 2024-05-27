using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos.GenreDtos;
using MovieApi.Dtos.MovieDtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IGenreRepo
    {
        Task<Genre> PostAsync(GenreRequest genreDto);
        Task<List<Genre>> GetAllAsync();
        Task<GenreResponse?> GetByIdAsync(int Id);
        Task<Genre?> UpdateAsync(int Id, GenreRequest genreDto);
        Task<Genre?> DeleteAsync(int Id);




    }
}