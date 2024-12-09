using AutoMapper;
using MC.Shared.Contracts.Repositories;
using MC.Shared.Models.Dtos.Members;
using MC.Shared.Models.Entities;
using MC.Shared.Results;
using MediatR;

namespace MC.Core.Members.Commands
{
    public class MemberCommandHandler : IRequestHandler<CreateMemberCommand, Result<MemberDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<Result<MemberDto>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            // Convert command to a entity
            var entity = _mapper.Map<Member>(request);

            // Create new member in the database
            var result = await _memberRepository.CreateAsync(entity, cancellationToken: cancellationToken);

            // Convert entity to dto
            var dto = _mapper.Map<MemberDto>(result);

            return Result<MemberDto>.Success(dto);
        }
    }
}
