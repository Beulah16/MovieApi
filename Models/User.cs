using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MovieApi.Models
{
    public class User : IdentityUser
    {
        public bool HasSubscribed { get; set;} = false;
        public List<WatchList> Watchlist { get; set; } = [];
    }
}