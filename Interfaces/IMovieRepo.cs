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
        Task<List<Movie>> GetAllAsync(QueryObject query, User user);
        Task<Movie> PostAsync(MovieRequest newMovie);
        Task<Movie?> GetByIdAsync(Guid id);
        Task<Movie?> UpdateAsync(Guid id, MovieRequest newMovie);
        Task<Movie?> DeleteAsync(Guid id);
        Task<Movie?> ReleaseAsync(Guid id);
    }
}