using System.ComponentModel.DataAnnotations;

namespace MovieApi.Dtos
{
    public class MovieRequest
    {
        [Required]
        [MinLength(5, ErrorMessage = "Title must be a minimum of 5 characters")]
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSubscribable { get; set; } = false;
        [Url]
        public string CoverImage { get; set; } = string.Empty;
        [Url]
        public string Trailer { get; set; } = string.Empty;
        [Url]
        public string Url { get; set; } = string.Empty;
    }
}