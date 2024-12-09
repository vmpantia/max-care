using MC.Shared.Results.Errors.Enumerations;

namespace MC.Shared.Results.Errors
{
    public class MemberError
    {
        public static Error NotFound(Guid id) => new(ErrorType.NotFound, $"Member with an Id of {id} is not found in the database.");
    }
}
