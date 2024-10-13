using System.Runtime.Serialization;

namespace WebApi.Models
{
    [DataContract]
    public class SetMatchView
    {
        [DataMember(Name = "setId")]
        public int SetId { get; set; }

        [DataMember(Name = "matchNumber")]
        public int MatchNumber { get; set; }
        
        [DataMember(Name = "playerOneCharacter")]
        public string PlayerOneCharacter { get; set; } = string.Empty;

        [DataMember (Name = "isPlayerOneMainCharacter")]
        public bool IsPlayerOneMainCharacter { get; set; }

        [DataMember(Name = "playerTwoCharacter")]
        public string PlayerTwoCharacter { get; set; } = string.Empty;

        [DataMember(Name = "isPlayerTwoMainCharacter")]
        public bool IsPlayerTwoMainCharacter { get; set; }

        [DataMember(Name = "playerMatchWinner")]
        public string PlayerMatchWinner { get; set; } = string.Empty;


    }
}
