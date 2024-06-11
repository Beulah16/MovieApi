using MovieApi.Dtos.SubscriptionDtos;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface ISubscriptionRepository
    {
        Task<List<SubscriptionPlan>> GetPlansAsync();
        Task<SubscriptionPlan> PostPlanAsync(PlanRequest request);
        Task<SubscriptionPlan> SubscribeAsync(User user);

    }
}