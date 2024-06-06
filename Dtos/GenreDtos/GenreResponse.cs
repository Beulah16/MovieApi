namespace MovieApi.Dtos.MovieDtos
{
    public class GenreResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<MovieResponse> Movies { get; set; } = [];
    }
}