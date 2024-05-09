using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos
{
    public class ReviewRequestDto
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        [Range(1, 5)]
        public decimal Rating { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        
    }
}