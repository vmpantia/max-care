using MC.Shared.Models.Dtos.Members;
using MC.Shared.Results;
using MC.Shared.Results.Errors;
using MediatR;

namespace MC.Core.Members.Queries
{
    public class GetMembersQuery : IRequest<Result<IEnumerable<MemberDto>, Error>> { }
}
