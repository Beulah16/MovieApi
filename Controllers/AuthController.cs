using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Data;
using MovieApi.Models;

namespace MovieApi.Controllers
{
    // [Route("/api/user")]
    [ApiController]
    public class AuthController(SignInManager<User> signIn) : ControllerBase
    {
        private readonly SignInManager<User> _signIn = signIn;
        [HttpPost("/api/auth/logout")]
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