using classwork.Data;
using Humanizer.Localisation;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace classwork.Models
{
    public class GameModel
    {
        public string Title { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int SalesCount
        {
            get; set;
        }

        public GameModel(string title, string studio, string genre, DateTime releaseDate, int salesCount)
        {
            Title = title;
            Studio = studio;
            Genre = genre;
            ReleaseDate = releaseDate;
            SalesCount = salesCount;
        }

        public GameModel()
        {

        }
    }
        public class GameModelExtension
        {
            public static Game ToGameWithId(int id, string user_id, GameModel model) => new()
            {
                Id = id,
                Title = model.Title,
                Studio = model.Studio,
                Genre = model.Genre,
                ReleaseDate = model.ReleaseDate,
                SalesCount = model.SalesCount,
                UserId = user_id
            };

            public static Game ToGame(string user_id, GameModel model) => new(model.Title, model.Studio, model.Genre, model.ReleaseDate, model.SalesCount, user_id);

            public static GameModel ToModel(Game game) => new(game.Title, game.Studio, game.Genre, game.ReleaseDate, game.SalesCount);
        }
}
