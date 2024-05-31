using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos.ReviewDtos
{
    public class ReviewResponseDto
    {
        public Guid Id { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Content { get; set; } = string.Empty;
    }
}