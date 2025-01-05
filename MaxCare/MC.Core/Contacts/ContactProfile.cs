using AutoMapper;
using MC.Infrastructure.Models.Entities;
using MC.Shared.Models.Dtos.Contacts;

namespace MC.Core.Contacts
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDto>()
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.EditedBy ?? src.CreatedBy))
                .ForMember(dst => dst.LastModifiedAtUtc, opt => opt.MapFrom(src => src.EditedAtUtc ?? src.CreatedAtUtc));
        }
    }
}
