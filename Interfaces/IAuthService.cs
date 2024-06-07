using System.Security.Claims;
using MovieApi.Models;

namespace MovieApi.Interfaces
{
    public interface IAuthService
    {
        void CheckIfAuthenticated(ClaimsPrincipal user);
        string GetUserId(ClaimsPrincipal user);
        Task<User> GetUserData(string userId);
    }
}