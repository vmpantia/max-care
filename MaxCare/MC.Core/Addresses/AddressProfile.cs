using AutoMapper;
using MC.Shared.Models.Dtos.Addresses;
using MC.Shared.Models.Entities;

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
