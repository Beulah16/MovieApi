using MovieApi.Modules.Review.Dtos;

namespace MovieApi.Dtos.ReviewDtos
{
    public class ReviewResponse : ReviewDTO
    {
        public Guid Id { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
    }
}