using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MovieApi.Exceptions;
using MovieApi.Interfaces;
using MovieApi.Models;

namespace MovieApi.Services
{
    public class AuthService(UserManager<User> user) : IAuthService
    {
        private readonly UserManager<User> _user = user;

        public void CheckIfAuthenticated(ClaimsPrincipal user)
        {
            if (GetUserId(user).IsNullOrEmpty())
                throw new UserNotAuthenticatedException("You're not a registered user");
        }

        public string GetUserId(ClaimsPrincipal user)
        {
            return user.FindFirstValue(ClaimTypes.NameIdentifier) ?? string.Empty;
        }

        public async Task<User> GetUserData(string userId)
        {
            return await _user.FindByIdAsync(userId)
                ?? throw new UserNotAuthenticatedException("You're not a registered user!");
        }
    }
}