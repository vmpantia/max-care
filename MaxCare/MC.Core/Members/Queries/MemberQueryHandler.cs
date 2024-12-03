using AutoMapper;
using MC.Shared.Contracts.Repositories;
using MC.Shared.Models.Dtos;
using MediatR;

namespace MC.Core.Members.Queries
{
    public sealed class MemberQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<MemberDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberQueryHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            // Get members from the database
            var result = await _memberRepository.GetMembersAsync(cancellationToken);

            return _mapper.Map<IEnumerable<MemberDto>>(result);
        }
    }
}
