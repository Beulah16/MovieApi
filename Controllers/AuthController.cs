using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieApi.Models;

namespace MovieApi.Controllers
{
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