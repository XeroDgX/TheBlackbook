using System.Runtime.Serialization;

namespace WebApi.Models
{
    [DataContract]
    public class Game
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; } = string.Empty;

        [DataMember(Name = "isActive")]
        public bool IsActive { get; set; }
    }
}
