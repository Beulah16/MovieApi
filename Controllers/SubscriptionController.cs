using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Dtos.SubscriptionDtos;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    [Route("api/subscription/")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionPlanRepo _subRepo;
        private readonly UserManager<User> _user;
        private readonly MovieDbContext _dbContext;
        public SubscriptionController(ISubscriptionPlanRepo subRepo, UserManager<User> user, MovieDbContext dbContext)
        {
            _subRepo = subRepo;
            _user = user;
            _dbContext = dbContext;
        }

        [HttpGet("plans")]
        public async Task<IActionResult> GetPlans()
        {
            var plan = await _subRepo.GetPlansAsync();
            return Ok(plan);
        }

        [HttpPost("create")]
        public async Task<IActionResult> PostPlan(PlanRequest request)
        {
            var plan = await _subRepo.PostPlanAsync(request);

            return Ok(plan);
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> Subscribe()
        {
            var user = await _user.FindByNameAsync(User.Identity.Name);
            if (user == null) return NotFound("You're not a registered user");

            user.HasSubscribed = true;
            await _dbContext.SaveChangesAsync();

            return Ok("Subscription successful");
        }
    }
}