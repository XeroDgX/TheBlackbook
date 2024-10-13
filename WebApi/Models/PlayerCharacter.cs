namespace WebApi.Models
{
    public class PlayerCharacter
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int GameId { get; set; }
        public int CharacterId { get; set; }
        public bool IsMain { get; set; }

    }
}
