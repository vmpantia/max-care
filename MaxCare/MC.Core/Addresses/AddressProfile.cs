using AutoMapper;
using MC.Infrastructure.Models.Entities;
using MC.Shared.Models.Dtos.Addresses;

namespace MC.Core.Addresses
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>()
                .ForMember(dst => dst.LastModifiedBy, opt => opt.MapFrom(src => src.EditedBy ?? src.CreatedBy))
                .ForMember(dst => dst.LastModifiedAtUtc, opt => opt.MapFrom(src => src.EditedAtUtc ?? src.CreatedAtUtc));
        }
    }
}
