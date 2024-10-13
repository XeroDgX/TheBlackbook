using System.Runtime.Serialization;

namespace WebApi.Models
{
    [DataContract]
    public class SetView
    {
        [DataMember(Name = "playerOne")]
        public string PlayerOne { get; set; } = string.Empty;

        [DataMember(Name = "playerTwo")]
        public string PlayerTwo { get; set; } = string.Empty;

        [DataMember(Name = "gameTitle")]
        public string GameTitle { get; set; } = string.Empty;

        [DataMember (Name = "matchDate")]
        public DateOnly MatchDate { get; set; }

        [DataMember (Name = "isOffline")]
        public bool IsOffline { get; set; }

        [DataMember (Name = "isMoneyMatch")]
        public bool IsMoneyMatch { get; set; }

        [DataMember (Name = "isLockedCharacters")]
        public bool IsLockedCharacters { get; set; }

        [DataMember (Name = "matchesToWin")]
        public int MatchesToWin { get; set; }

        [DataMember (Name = "playerWinner")]
        public string PlayerWinner { get; set; } = string.Empty;

        [DataMember(Name = "matches")]
        public virtual required ICollection<SetMatchView> Matches { get; set; }
    }
}
