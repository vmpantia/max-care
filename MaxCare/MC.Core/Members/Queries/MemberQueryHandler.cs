using AutoMapper;
using MC.Shared.Contracts.Repositories;
using MC.Shared.Models.Dtos.Addresses;
using MC.Shared.Models.Dtos.Contacts;
using MC.Shared.Models.Dtos.Members;
using MC.Shared.Results;
using MC.Shared.Results.Errors;
using MediatR;

namespace MC.Core.Members.Queries
{
    public sealed class MemberQueryHandler : 
        IRequestHandler<GetMembersQuery, Result<IEnumerable<MemberDto>>>,
        IRequestHandler<GetMemberByIdQuery, Result<MemberDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public MemberQueryHandler(IMemberRepository memberRepository, IAddressRepository addressRepository,
            IContactRepository contactRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _addressRepository = addressRepository;
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<MemberDto>>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var dtos = new List<MemberDto>();

            // Get members from the database
            var members = await _memberRepository.GetMembersAsync(cancellationToken);

            // Populate other informations of member
            foreach (var member in members)
            {
                // Convert entity to dto
                var dto = _mapper.Map<MemberDto>(member);

                // Get member addresses
                var addresses = await _addressRepository.GetMemberAddressesAsync(member.Id, cancellationToken);
                dto.Addresses = _mapper.Map<IEnumerable<AddressDto>>(addresses);

                // Get member contacts
                var contacts = await _contactRepository.GetMemberContactsAsync(member.Id, cancellationToken);
                dto.Contacts = _mapper.Map<IEnumerable<ContactDto>>(contacts);

                dtos.Add(dto);
            }

            return Result<IEnumerable<MemberDto>>.Success(dtos);
        }

        public async Task<Result<MemberDto>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
        {
            // Get member from the database using id
            var member = await _memberRepository.GetMemberByIdAsync(request.Id, cancellationToken);

            // Check if the member is NULL
            if (member is null) 
                return Result<MemberDto>.Failure(MemberError.NotFound(request.Id));

            // Convert entity to dto
            var dto = _mapper.Map<MemberDto>(member);

            // Get member addresses
            var addresses = await _addressRepository.GetMemberAddressesAsync(member.Id, cancellationToken);
            dto.Addresses = _mapper.Map<IEnumerable<AddressDto>>(addresses);

            // Get member contacts
            var contacts = await _contactRepository.GetMemberContactsAsync(member.Id, cancellationToken);
            dto.Contacts = _mapper.Map<IEnumerable<ContactDto>>(contacts);

            return Result<MemberDto>.Success(dto);
        }
    }
}
