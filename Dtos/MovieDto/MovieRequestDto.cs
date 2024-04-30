using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos.ReviewDto;
using MovieApi.Models;

namespace MovieApi.Dtos.MovieDto
{
    public class MovieRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public DateTime ReleasedOn { get; set;}

    }
}