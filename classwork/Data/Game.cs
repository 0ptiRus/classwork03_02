namespace classwork.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Studio { get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int SalesCount { get; set; }
        public string UserId { get; set; }

        public Game(string title, string studio, string genre, DateTime releaseDate, int salesCount, string userId)
        {
            Title = title;
            Studio = studio;
            Genre = genre;
            ReleaseDate = releaseDate;
            SalesCount = salesCount;
            UserId = userId;
        }

        public Game()
        {
        }
    }
}
