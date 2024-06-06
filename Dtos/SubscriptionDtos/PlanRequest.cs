namespace MovieApi.Dtos.SubscriptionDtos
{
    public class PlanRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Benefits { get; set; } = [];
        public List<string> Limitations { get; set; } = [];
    }
}