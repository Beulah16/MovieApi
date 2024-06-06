namespace MovieApi.Dtos.ReviewDtos
{
    public class ReviewResponseDto
    {
        public Guid Id { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
    }
}