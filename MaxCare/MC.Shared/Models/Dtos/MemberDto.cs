using MC.Shared.Models.Enumerations;

namespace MC.Shared.Models.Dtos
{
    public class MemberDto
    {
        public required Guid Id { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required Gender Gender { get; set; }
        public required DateTime Birthdate { get; set; }
        public required MemberType Type { get; set; }
        public required Status Status { get; set; }
        public required string LastModifiedBy { get; set; }
        public required DateTime LastModifiedAtUtc { get; set; }

        public GroupDto? Group { get; set; }
        public IEnumerable<AddressDto> Addresses { get; set; }
        public IEnumerable<ContactDto> Contacts { get; set; }
    }
}
