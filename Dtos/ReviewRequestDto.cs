using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos
{
    public class ReviewRequestDto
    {
        public int MovieId { get; set; }
        public decimal Rating { get; set; }
        public string Content { get; set; } = string.Empty;
        
    }
}