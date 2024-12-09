using MC.Shared.Models.Dtos.Addresses;
using MC.Shared.Models.Dtos.Contacts;
using MC.Shared.Models.Enumerations;

namespace MC.Shared.Models.Dtos.Groups
{
    public class GroupDto
    {
        public required Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required Status Status { get; set; }
        public required string LastModifiedBy { get; set; }
        public required DateTime LastModifiedAtUtc { get; set; }

        public IEnumerable<AddressDto> Addresses { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
    }
}
