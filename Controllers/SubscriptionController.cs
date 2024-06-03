using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Dtos.SubscriptionDtos;
using MovieApi.Interfaces;

namespace MovieApi.Controllers
{
    [Route("api/subscription/")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionPlanRepo _subRepo;
        public SubscriptionController(ISubscriptionPlanRepo subRepo)
        {
            _subRepo = subRepo;
        }

        [HttpGet("plans")]
        public async Task<IActionResult> GetPlans()
        {
            var plan = await _subRepo.GetPlansAsync();
            return Ok(plan);
        }

        [HttpPost]
        public async Task<IActionResult> PostPlan(SubscriptionRequest request)
        {
            var plan = await _subRepo.PostPlanAsync(request);
            
            return Ok(plan);
        }
    }
}