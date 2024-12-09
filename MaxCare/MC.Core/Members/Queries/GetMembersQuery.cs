using MC.Shared.Models.Dtos.Members;
using MC.Shared.Results;
using MediatR;

namespace MC.Core.Members.Queries
{
    public class GetMembersQuery : IRequest<Result<IEnumerable<MemberDto>>> { }
}
