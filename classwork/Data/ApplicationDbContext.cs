using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace classwork.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Game> Games { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    //protected override void OnModelCreating(ModelBuilder builder)
    //{
    //    builder.Entity<Game>().HasData(new Game { Id = 1, Title = "Cyberpunk 2077", Studio = "CD Projekt Red", Genre = "Action RPG", ReleaseDate = new DateTime(2020, 12, 10), SalesCount = 10000000 },
    //        new Game { Id = 2, Title = "The Witcher 3: Wild Hunt", Studio = "CD Projekt Red", Genre = "RPG", ReleaseDate = new DateTime(2015, 05, 19), SalesCount = 5000000 },
    //        new Game { Id = 3, Title = "Call of Duty: Modern Warfare", Studio = "Activision", Genre = "FPS", ReleaseDate = new DateTime(2019, 10, 25), SalesCount = 20000000 },
    //        new Game { Id = 4, Title = "Red Dead Redemption 2", Studio = "Rockstar Games", Genre = "Action Adventure", ReleaseDate = new DateTime(2018, 10, 26), SalesCount = 15000000 },
    //        new Game { Id = 5, Title = "Minecraft", Studio = "Mojang Studios", Genre = "Sandbox", ReleaseDate = new DateTime(2011, 11, 18), SalesCount = 30000000 });
    //}
}
