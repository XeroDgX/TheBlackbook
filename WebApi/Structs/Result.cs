using WebApi.Helpers.Models;

namespace WebApi.Structs
{
    public readonly struct Result<T>
    {
        private readonly bool _success;
        public readonly T Data;
        public readonly List<ErrorMessage> ErrorResponse;
        public readonly string ExceptionMessage;


        private Result(T v, List<ErrorMessage> error, bool success)
        {
            Data = v;
            ErrorResponse = error;
            _success = success;
        }

        private Result(Exception error, bool success)
        {
            ExceptionMessage = error.Message;
            _success = success;
        }

        public bool IsSuccess => _success;

        public static Result<T> Ok(T v)
        {
            return new(v, default!, true);
        }

        public static Result<List<ErrorMessage>> Err(List<ErrorMessage> v)
        {
            return new(default!, v, true);
        }

        public static Result<string> Ex(Exception v)
        {
            return new(v, true);
        }

        public static implicit operator Result<T>(T v) => new(v, default!, true);
        public static implicit operator Result<T>(List<ErrorMessage> e) => new(default!, e, false);
        public static implicit operator Result<T>(Exception e) => new(e, false);

        private R Match<R>(
                Func<T, R> success,
                Func<string, R> exception,
                Func<List<ErrorMessage>, R> failure) =>
            _success ? success(Data) : ExceptionMessage is not null? exception(ExceptionMessage):  failure(ErrorResponse);
    }
}
