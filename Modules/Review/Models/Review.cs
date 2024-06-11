using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}