namespace WebApi.Models
{
    public class SetMatch
    {
        public int Id { get; set; }
        public int SetId { get; set; }
        public int MatchNumber { get; set; }
        public int PlayerOneCharacterId { get; set; }
        public bool IsPlayerOneCharacterMain { get; set; }
        public int PlayerTwoCharacterId { get; set; }
        public bool IsPlayerTwoCharacterMain { get; set; }
        public int MatchWinnerPlayerId { get; set; }
    }
}
