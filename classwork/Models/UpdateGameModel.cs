namespace classwork.Models
{
    public class UpdateGameModel : GameModel
    {
        public int Id { get; set; }
        public string UserId {  get; set; }

        public UpdateGameModel(string title, string studio, string genre, DateTime releaseDate, int salesCount, int id, string userId) : 
            base(title, studio, genre, releaseDate, salesCount)
        {
            Id = id;
            UserId = userId;
        }


        public UpdateGameModel() { }
    }
}
