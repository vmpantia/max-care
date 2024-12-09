using MC.Shared.Results.Errors.Enumerations;

namespace MC.Shared.Results.Errors
{
    public sealed record Error(ErrorType Type, string Description, Exception? Exception = null) { }
}
