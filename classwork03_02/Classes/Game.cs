namespace classwork03_02.Classes
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Developer {  get; set; }
        public string Genre { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int SalesCount { get; set; }

        public Game(string name, string developer, string genre, DateTime releaseDate, int salesCount)
        {
            Name = name;
            Developer = developer;
            Genre = genre;
            ReleaseDate = releaseDate;
            SalesCount = salesCount;
        }

        public Game()
        {
        }
    }
}
