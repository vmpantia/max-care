using MC.Shared.Models.Dtos;
using MediatR;

namespace MC.Core.Members.Queries
{
    public class GetMembersQuery : IRequest<IEnumerable<MemberDto>> { }
}
