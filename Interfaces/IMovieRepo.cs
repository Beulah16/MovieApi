using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos;
using MovieApi.Helpers;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IMovieRepo
    {
        Task<Movie> PostAsync(MovieRequestDto newMovie);
        Task<List<Movie>> GetAllAsync(QueryObject query);
        Task<Movie?> GetByIdAsync(int id);
        Task<Movie?> UpdateAsync(int id, MovieRequestDto newMovie);
        Task<Movie?> DeleteAsync(int id);
        Task<Movie?> ReleaseAsync(int id);  
    }
}