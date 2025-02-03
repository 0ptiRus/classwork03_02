using Microsoft.EntityFrameworkCore;

namespace classwork03_02.Classes
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Game> Games { get; set; }


    }
}
