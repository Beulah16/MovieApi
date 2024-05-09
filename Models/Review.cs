using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieApi.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rating { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime? CreatedOn { get; }
        public DateTime? UpdatedOn { get; }
    }
}