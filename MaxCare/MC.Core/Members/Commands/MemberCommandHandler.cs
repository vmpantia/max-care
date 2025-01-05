using AutoMapper;
using MC.Infrastructure.Databases.Contracts;
using MC.Infrastructure.Models.Entities;
using MC.Shared.Models.Dtos.Members;
using MC.Shared.Results;
using MC.Shared.Results.Errors;
using MediatR;

namespace MC.Core.Members.Commands
{
    public class MemberCommandHandler : 
        IRequestHandler<CreateMemberCommand, Result<MemberDto, Error>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberCommandHandler(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<Result<MemberDto, Error>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            // Convert command to a entity
            var entity = _mapper.Map<Member>(request);

            // Create new member in the database
            var result = await _memberRepository.CreateAsync(entity, cancellationToken: cancellationToken);

            // Convert entity to dto
            var dto = _mapper.Map<MemberDto>(result);

            return dto;
        }
    }
}
