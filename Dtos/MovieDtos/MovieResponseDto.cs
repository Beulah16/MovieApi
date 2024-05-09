using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Dtos
{
    public class MovieResponseDto : MovieRequestDto
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ReleasedOn { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; }
        
        [DataType(DataType.Date)]
        public DateTime? UpdatedOn { get; }
        public List<ReviewRequestDto> Reviews { get; set; } = new List<ReviewRequestDto>();

    }
}