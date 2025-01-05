using AutoMapper;
using MC.Core.Members.Commands;
using MC.Infrastructure.Models.Entities;
using MC.Shared.Models.Dtos.Members;

namespace MC.Core.Members
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, MemberDto>()
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.EditedBy ?? src.CreatedBy))
                .ForMember(dst => dst.LastModifiedAtUtc, opt => opt.MapFrom(src => src.EditedAtUtc ?? src.CreatedAtUtc))
                .ForMember(dst => dst.Contacts, opt => opt.Ignore())
                .ForMember(dst => dst.Addresses, opt => opt.Ignore());

            CreateMap<CreateMemberCommand, Member>();
        }
    }
}
