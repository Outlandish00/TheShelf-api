using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TheShelf.Models;

namespace TheShelf.Data;

public class TheShelfDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    public DbSet<Movie> Movies { get; set; }
    public DbSet<WatchList> Watchlists { get; set; }
    public DbSet<WatchListMedia> WatchListMedias { get; set; }
    public DbSet<MediaLike> MediaLikes { get; set; }
    public DbSet<MediaComment> MediaComments { get; set; }

    public TheShelfDbContext(DbContextOptions<TheShelfDbContext> context, IConfiguration config)
        : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<IdentityRole>()
            .HasData(
                new IdentityRole
                {
                    Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    Name = "Admin",
                    NormalizedName = "admin",
                }
            );

        modelBuilder
            .Entity<IdentityUser>()
            .HasData(
                new IdentityUser
                {
                    Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    UserName = "Administrator",
                    Email = "admina@strator.comx",
                    PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(
                        null,
                        _configuration["AdminPassword"]
                    ),
                }
            );

        modelBuilder
            .Entity<IdentityUserRole<string>>()
            .HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                    UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                }
            );
        modelBuilder
            .Entity<UserProfile>()
            .HasData(
                new UserProfile
                {
                    Id = 1,
                    IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                    FirstName = "Admina",
                    LastName = "Strator",
                    UserName = "AdminaStrator",
                }
            );
        modelBuilder
            .Entity<Movie>()
            .HasData(
                new Movie { Id = 1, imbdId = "tt0322802" },
                new Movie { Id = 2, imbdId = "tt0499549" }
            );
        modelBuilder
            .Entity<WatchList>()
            .HasData(
                new WatchList
                {
                    Id = 1,
                    Title = "To be watched",
                    UserId = 1,
                    IsPrivate = false,
                }
            );
        modelBuilder
            .Entity<WatchListMedia>()
            .HasData(
                new WatchListMedia
                {
                    Id = 1,
                    WatchListId = 1,
                    MovieId = 1,
                }
            );

        //These handle cascading deletions
        modelBuilder
            .Entity<WatchList>()
            .HasMany(w => w.WatchListMedia)
            .WithOne(wm => wm.Watchlist)
            .HasForeignKey(wm => wm.WatchListId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder
            .Entity<Movie>()
            .HasMany(m => m.WatchListMedia)
            .WithOne(wm => wm.Movie)
            .HasForeignKey(wm => wm.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
