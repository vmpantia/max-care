using MC.Shared.Results.Errors.Enumerations;

namespace MC.Shared.Results.Errors
{
    public class CommonError
    {
        public static Error Exception(Exception ex) =>
            new(ErrorType.Exception,
                $"Unexpected error occurred while processing the request, {ex.Message}",
                Exception: ex);
    }
}
