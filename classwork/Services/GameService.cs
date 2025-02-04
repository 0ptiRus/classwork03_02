using classwork.Data;
using Microsoft.EntityFrameworkCore;

namespace classwork.Services
{
    public class GameService
    {
        private readonly ApplicationDbContext context;
        private readonly List<Game> data = new()
             {
            new Game {Title = "Cyberpunk 2077", Studio = "CD Projekt Red", Genre = "Action RPG", ReleaseDate = new DateTime(2020, 12, 10), SalesCount = 10000000},
            new Game {Title = "The Witcher 3: Wild Hunt", Studio = "CD Projekt Red", Genre = "RPG", ReleaseDate = new DateTime(2015, 05, 19), SalesCount = 5000000},
            new Game {Title = "Call of Duty: Modern Warfare", Studio = "Activision", Genre = "FPS", ReleaseDate = new DateTime(2019, 10, 25), SalesCount = 20000000},
            new Game {Title = "Red Dead Redemption 2", Studio = "Rockstar Games", Genre = "Action Adventure", ReleaseDate = new DateTime(2018, 10, 26), SalesCount = 15000000},
            new Game {Title = "Minecraft", Studio = "Mojang Studios", Genre = "Sandbox", ReleaseDate = new DateTime(2011, 11, 18),SalesCount = 30000000},
        };
        public GameService(ApplicationDbContext context)
        {
            this.context = context;
            //if (context.Games.Count() == 0 && context.Games is null)
            //{
            //    context.Games.AddRange(data);
            //    context.SaveChanges();
            //}
        }

        public async Task<Game> GetById(int id) => await context.Games.FindAsync(id);
        public async Task<Game> GetOneByTitle(string title) => await context.Games.FirstOrDefaultAsync(g => g.Title == title);
        public async Task<IList<Game>> GetAll() => await context.Games.ToListAsync();

        public async Task<IList<Game>> GetByTitle(string title) => await context.Games.Where(g => g.Title == title).ToListAsync();
        public async Task<IList<Game>> GetByStudio(string studio) => await context.Games.Where(g => g.Studio == studio).ToListAsync();
        public async Task<IList<Game>> GetByGenre(string genre) => await context.Games.Where(g => g.Genre == genre).ToListAsync();
        public async Task<IList<Game>> GetByReleaseYear(int year) => await context.Games.Where(g=> g.ReleaseDate.Year == year).ToListAsync();
        public async Task<Game> GetMostSoldGame() => await context.Games.OrderByDescending(g => g.SalesCount).FirstOrDefaultAsync();
        public async Task<Game> GetLeastSoldGame() => await context.Games.OrderBy(g => g.SalesCount).FirstOrDefaultAsync();

        public async Task<IList<Game>> Get3MostSold() => await context.Games.OrderByDescending(g => g.SalesCount).Take(3).ToListAsync();
        public async Task<IList<Game>> Get3LeastSold() => await context.Games.OrderBy(g => g.SalesCount).Take(3).ToListAsync();

        public async Task<Game> Create(Game game)
        {
            Game search = await GetOneByTitle(game.Title);
            if(search != null)
            {
                throw new Exception("Такая игра уже существует!");
            }
            await context.Games.AddAsync(game);
            await context.SaveChangesAsync();
            return game;
        }

        public async Task<IList<Game>> FillDb()
        {
            await context.AddRangeAsync(data);
            await context.SaveChangesAsync();
            return data;
        }

        public async Task<Game> Update(Game game)
        {
            context.Games.Update(game);
            await context.SaveChangesAsync();
            return game;
        }

        public async Task<bool> Remove(Game game)
        {
            context.Games.Remove(game);
            await context.SaveChangesAsync();
            return true;
        }

    }
}
