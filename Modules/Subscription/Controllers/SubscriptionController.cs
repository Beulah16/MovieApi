using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Interfaces;

namespace MovieApi.Controllers
{
    [Route("api/subscription/")]
    [ApiController]
    public class SubscriptionController(ISubscriptionRepository subRepo, IAuthService authService, MovieDbContext dbContext) : ControllerBase
    {
        private readonly ISubscriptionRepository _subRepo = subRepo;
        private readonly IAuthService _authService = authService;
        private readonly MovieDbContext _dbContext = dbContext;

        [HttpGet("plans")]
        public async Task<IActionResult> GetPlans()
        {
            var plan = await _subRepo.GetPlansAsync();
            return Ok(plan);
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe()
        {
            _authService.CheckIfAuthenticated(User);

            var user = await _authService.GetUserData(_authService.GetUserId(User));

            user.HasSubscribed = true;
            await _dbContext.SaveChangesAsync();

            return Ok("Subscription successful");
        }

        [HttpDelete("cancel")]
        public async Task<IActionResult> CancelSubscription()
        {
            _authService.CheckIfAuthenticated(User);

            var user = await _authService.GetUserData(_authService.GetUserId(User));

            user.HasSubscribed = true;
            await _dbContext.SaveChangesAsync();

            return Ok("Subscription successfully cancelled");
        }
    }
}