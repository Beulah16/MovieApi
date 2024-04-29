using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos.ReviewDto
{
    public class ReviewForMovieResponseDto
    {
        public decimal Rating { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}