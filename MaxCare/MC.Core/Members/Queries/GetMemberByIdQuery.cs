﻿using MC.Shared.Models.Dtos.Members;
using MediatR;

namespace MC.Core.Members.Queries
{
    public record GetMemberByIdQuery(Guid Id) : IRequest<MemberDto> { }
}
