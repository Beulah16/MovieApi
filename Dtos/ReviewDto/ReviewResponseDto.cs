using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos.ReviewDto
{
    public class ReviewResponseDto
    {
        public int Id { get; set; }
        public decimal Rating { get; set; }
        public string Content { get; set; }= string.Empty;
        public int MovieId { get; set; }
    }
}