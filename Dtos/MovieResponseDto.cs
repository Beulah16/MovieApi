using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos
{
    public class MovieResponseDto
    {
        public int Id { get; set;}
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? ReleasedOn { get; set; }
        public string Genre { get; set; } = string.Empty;
        public List<ReviewRequestDto> Reviews{ get; set; } = new List<ReviewRequestDto>();

    }
}