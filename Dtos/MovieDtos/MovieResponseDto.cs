using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MovieApi.Dtos.ReviewDtos;

namespace MovieApi.Dtos
{
    public class MovieResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        [DataType(DataType.Date)]
        public DateTime? ReleasedOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; }

        [DataType(DataType.Date)]
        public DateTime? UpdatedOn { get; }
    }
}