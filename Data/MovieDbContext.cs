using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data
{
    public class MovieDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Movie> Movies { get; set;}
        public DbSet<Review> Reviews { get; set;}

    }
}