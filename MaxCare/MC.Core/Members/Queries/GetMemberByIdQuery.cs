using MC.Shared.Models.Dtos.Members;
using MC.Shared.Results;
using MediatR;

namespace MC.Core.Members.Queries
{
    public record GetMemberByIdQuery(Guid Id) : IRequest<Result<MemberDto>> { }
}
