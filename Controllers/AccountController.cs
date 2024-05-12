using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;

namespace MovieApi.Controllers
{
    // [Route("/api/user")]
    [ApiController]
    public class AccountController(SignInManager<User> signIn) : ControllerBase
    {
        private readonly SignInManager<User> _signIn = signIn;
        [HttpPost("/api/user/logout")]
        public async Task<IActionResult> Post([FromBody] object empty)
        {
            if(empty !=null)
            {
                await _signIn.SignOutAsync();
                return Ok();
            }
            return Unauthorized("Logged out");
        }

    }
}