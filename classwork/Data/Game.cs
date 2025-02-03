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

        public Game(string name, string developer, string genre, DateTime releaseDate, int salesCount)
        {
            Title = name;
            Studio = developer;
            Genre = genre;
            ReleaseDate = releaseDate;
            SalesCount = salesCount;
        }

        public Game()
        {
        }
    }
}
