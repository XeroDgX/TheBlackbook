namespace WebApi.Helpers.Models
{
    public static class ErrorMessagesCache
    {
        public static List<ErrorMessage> Messages { get; private set; } = new();

        public static void LoadMessages(List<ErrorMessage> errorMessages)
        {
            Messages = errorMessages;
        }
    }
}
