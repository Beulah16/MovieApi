using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rating { get; set; }
        public string Content { get; set; }= string.Empty;
        public Movie? Movie { get; set; }
    }
}