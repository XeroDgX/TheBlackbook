using System.Runtime.Serialization;

namespace WebApi.Helpers.Models
{
    [DataContract]
    public class ErrorMessage
    {
        [DataMember (Name = "errorCode")]
        public required int ErrorCode { get; set; }

        [DataMember (Name = "message")]
        public required string Message { get; set; }
    }
}
