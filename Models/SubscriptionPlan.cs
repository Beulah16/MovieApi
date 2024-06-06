using System.ComponentModel.DataAnnotations.Schema;

namespace MovieApi.Models
{
    public class SubscriptionPlan
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public List<string> Benefits { get; set; } = [];
        public List<string> Limitations { get; set; } = [];

    }
}