using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class ReviewRequestDto
    {
        // public int MovieId { get; set; }
        [Required]
        [Range(1, 5)]
        public decimal Rating { get; set; }
        [Required]
        public string Comment { get; set; } = string.Empty;
        
    }
}