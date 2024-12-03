using AutoMapper;
using MC.Shared.Contracts.Repositories;
using MC.Shared.Models.Dtos;
using MediatR;

namespace MC.Core.Members.Queries
{
    public sealed class MemberQueryHandler : IRequestHandler<GetMembersQuery, IEnumerable<MemberDto>>
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IContactRepository _contactRepository;
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public MemberQueryHandler(IMemberRepository memberRepository, IContactRepository contactRepository,
            IAddressRepository addressRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _contactRepository = contactRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var dtos = new List<MemberDto>();

            // Get members from the database
            var members = await _memberRepository.GetMembersAsync(cancellationToken);

            // Populate other informations of member
            foreach (var member in members)
            {
                // Convert entity to dto
                var dto = _mapper.Map<MemberDto>(member);

                // Get member contacts
                var contacts = await _contactRepository.GetMemberContactsAsync(member.Id, cancellationToken);
                dto.Contacts = _mapper.Map<IEnumerable<ContactDto>>(contacts);

                // Get member addresses
                var addresses = await _addressRepository.GetMemberAddressesAsync(member.Id, cancellationToken);
                dto.Addresses = _mapper.Map<IEnumerable<AddressDto>>(addresses);

                dtos.Add(dto);
            }

            return dtos;
        }
    }
}
