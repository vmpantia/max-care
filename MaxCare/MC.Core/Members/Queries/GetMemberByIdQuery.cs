using MC.Shared.Models.Dtos;
using MediatR;

namespace MC.Core.Members.Queries
{
    public record GetMemberByIdQuery(Guid Id) : IRequest<MemberDto> { }
}
