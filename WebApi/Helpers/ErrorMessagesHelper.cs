using WebApi.Enums;
using WebApi.Helpers.Models;

namespace WebApi.Helper
{
    public static class ErrorMessagesHelper
    {
        public static List<ErrorMessage> GetErrorMessage(ErrorCode errorCode)
        {
            return GetErrorMessages(new List<ErrorCode> { errorCode });
        }

        public static List<ErrorMessage> GetErrorMessages(List<ErrorCode> errorCodes)
        {
            List<ErrorMessage> errors = [];
            foreach (ErrorCode errorCode in errorCodes.Order())
            {
                var errorMessage = ErrorMessagesCache.Messages.FirstOrDefault(x => x.ErrorCode == (int)errorCode);
                if (errorMessage != null)
                    errors.Add(errorMessage);
            }
            return errors;
        }
    }
}
