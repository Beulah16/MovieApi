using MovieApi.Dtos.SubscriptionDtos;
using MovieApi.Models;

namespace MovieApi.Mappers
{
    public static class SubscriptionMappers
    {
        public static SubscriptionPlan ToPlanRequest (this PlanRequest plan)
        {
            return new SubscriptionPlan
            {
                Name = plan.Name,
                Description = plan.Description,
                Price = plan.Price,
                Benefits = plan.Benefits,
                Limitations = plan.Limitations,
            };
        }
    }
}