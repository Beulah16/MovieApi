using System.ComponentModel.DataAnnotations;
using MovieApi.Dtos.ReviewDtos;

namespace MovieApi.Dtos
{
    public class MovieResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsSubscribable { get; set; }
        [Url]
        public string CoverImage { get; set; } = string.Empty;
        [Url]
        public string Trailer { get; set;} = string.Empty;
        [Url]
        public string Url { get; set; } = string.Empty;
        public string? ReleasedOn { get; set; }
        public string? CreatedOn { get; set; }
        public List<ReviewResponseDto> Reviews { get; set; } = [];
    }
}