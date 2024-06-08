using MovieApi.Dtos.ReviewDtos;
using MovieApi.Modules.Movie.Dtos;

namespace MovieApi.Dtos
{
    public class MovieResponse : MovieDTO
    {
        public Guid Id { get; set; }
        public string? ReleasedOn { get; set; }
        public string? CreatedOn { get; set; }
        public List<ReviewResponse> Reviews { get; set; } = [];
    }
}