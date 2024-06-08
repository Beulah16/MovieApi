using System.ComponentModel.DataAnnotations;

namespace MovieApi.Modules.Review.Dtos
{
    public class ReviewDTO
    {
        [Required]
        [Range(1, 5)]
        public decimal Rating { get; set; }
        [Required]
        public string Comment { get; set; } = string.Empty;
    }
}