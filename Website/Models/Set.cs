using System.ComponentModel;

namespace Website.Models
{
    public class Set
    {
        public int Id { get; set; }

        [DisplayName("Player One")]
        public int PlayerOneId { get; set; }

        [DisplayName("Player Two")]
        public int PlayerTwoId { get; set; }

        [DisplayName("Game")]
        public int GameId { get; set; }

        [DisplayName("Set Date")]
        public DateTime Date { get; set; }

        [DisplayName("Is Offline Set?")]
        public bool IsOffline { get; set; }

        [DisplayName("Is Tournament Set?")]
        public bool IsTournament { get; set; }

        [DisplayName("Is Money Match Set?")]
        public bool IsMoneyMatch { get; set; }

        [DisplayName("Is Locked Characters?")]
        public bool IsLockedCharacters { get; set; }

        [DisplayName ("Matches To Win Set")]
        public int MatchesToWin { get; set; }

        [DisplayName("Set Winner")]
        public int WinnerPlayerId { get; set; }
        [DisplayName("Set Matches")]
        public List<SetMatch> SetMatches { get; set; } = [];
    }
}
