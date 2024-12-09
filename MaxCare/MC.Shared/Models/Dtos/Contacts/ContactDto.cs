using MC.Shared.Models.Enumerations;

namespace MC.Shared.Models.Dtos.Contacts
{
    public class ContactDto
    {
        public required Guid Id { get; set; }
        public required string Value { get; set; }
        public required string? Description { get; set; }
        public required bool IsPrimary { get; set; }
        public required ContactType Type { get; set; }
        public required Status Status { get; set; }
        public required string LastModifiedBy { get; set; }
        public required DateTime LastModifiedAtUtc { get; set; }
    }
}
