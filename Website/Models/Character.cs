namespace Website.Models
{
    public class Character
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int GameId { get; set; }
    }
}
