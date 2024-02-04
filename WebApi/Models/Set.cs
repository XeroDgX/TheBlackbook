namespace WebApi.Models
{
    public class Set
    {
        public int Id { get; set; }
        public int PlayerOneId { get; set; }
        public int PlayerTwoId { get; set; }
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public string Venue { get; set; } = string.Empty;
        public bool IsOffline { get; set; }
        public bool IsTournament { get; set; }
        public bool IsMoneyMatch { get; set; }
        public bool IsLockedChararacters { get; set; }
        public int MatchesToWin { get; set; }
        public List<SetMatch> SetMatches { get; set; } = new List<SetMatch>();
    }
}
