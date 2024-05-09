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
        Task<Movie> CreateAsync(MovieRequestDto newMovie);
        Task<List<Movie>> ReadAllAsync(QueryObject query);
        Task<Movie?> ReadByIdAsync(int id);
        Task<Movie?> UpdateAsync(int id, MovieRequestDto newMovie);
        Task<Movie?> DeleteAsync(int id);



    }
}