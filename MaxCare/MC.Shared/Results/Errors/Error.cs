using MC.Shared.Results.Errors.Enumerations;

namespace MC.Shared.Results.Errors
{
    public record Error(ErrorType Type, string Message, object? Value = null) { }
}
