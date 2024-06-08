using MovieApi.Modules.Genre.Dtos;

namespace MovieApi.Dtos.MovieDtos
{
    public class GenreResponse : GenreDTO
    {
        public Guid Id { get; set; }
        public List<MovieResponse> Movies { get; set; } = [];
    }
}