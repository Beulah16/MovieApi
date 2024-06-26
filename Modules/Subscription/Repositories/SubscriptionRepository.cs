using Microsoft.EntityFrameworkCore;
using MovieApi.Data;
using MovieApi.Dtos.SubscriptionDtos;
using MovieApi.Interfaces;
using MovieApi.Mappers;
using MovieApi.Models;

namespace MovieApi.Repository
{
    public class SubscriptionRepository(MovieDbContext dbContext) : ISubscriptionRepository
    {
        private readonly MovieDbContext _dbContext = dbContext;

        public async Task<List<SubscriptionPlan>> GetPlansAsync()
        {
            return await _dbContext.SubscriptionPlans.ToListAsync();
        }

        public async Task<SubscriptionPlan> PostPlanAsync(PlanRequest request)
        {
            var plan = request.ToPlanRequest();
            await _dbContext.SubscriptionPlans.AddAsync(plan);
            await _dbContext.SaveChangesAsync();

            return plan;
        }

        public Task<SubscriptionPlan> SubscribeAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}