using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;

namespace MovieApi.Data
{
    public class MovieDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<WatchList> WatchLists { get; set; }
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<WatchList>(w => w.HasKey(x => new { x.UserId, x.MovieId }));

            builder.Entity<WatchList>()
                .HasOne(u => u.User)
                .WithMany(u => u.Watchlist)
                .HasForeignKey(x => x.UserId);

            builder.Entity<WatchList>()
                .HasOne(u => u.Movie)
                .WithMany(u => u.Watchlist)
                .HasForeignKey(x => x.MovieId);
        }
    }
}