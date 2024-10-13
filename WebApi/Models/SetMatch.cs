namespace WebApi.Models
{
    public class SetMatch
    {
        public int Id { get; set; }
        public int SetId { get; set; }
        public int MatchNumber { get; set; }
        public int PlayerOneCharacterId { get; set; }
        public bool IsPlayerOneMainCharacter { get; set; }
        public int PlayerTwoCharacterId { get; set; }
        public bool IsPlayerTwoMainCharacter { get; set; }
        public int MatchWinnerPlayerId { get; set; }
    }
}
