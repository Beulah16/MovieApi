using Microsoft.AspNetCore.Identity;

namespace MovieApi.Models
{
    public class User : IdentityUser
    {
        public bool HasSubscribed { get; set;} = false;
        public List<WatchList> Watchlist { get; set; } = [];
    }
}