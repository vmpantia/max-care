using MC.Shared.Results.Errors;

namespace MC.Shared.Results
{
    public class Result<TData>
    {
        private Result()
        {
            Data = default;
            Error = null;
            IsSuccess = true;
        }

        private Result(TData data) 
        {
            Data = data;
            Error = null;
            IsSuccess = true;
        }

        private Result(Error error)
        {
            Data = default;
            Error = error;
            IsSuccess = true;
        }

        public TData? Data { get; init; }
        public Error? Error { get; init; }
        public bool IsSuccess { get; init; }

        public static Result<TData> Success() => new();
        public static Result<TData> Success(TData data) => new(data);
        public static Result<TData> Failure(Error error) => new(error);
    }
}
