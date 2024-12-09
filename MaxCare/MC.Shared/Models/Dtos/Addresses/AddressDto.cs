using MC.Shared.Models.Enumerations;

namespace MC.Shared.Models.Dtos.Addresses
{
    public class AddressDto
    {
        public required Guid Id { get; set; }
        public string FullAddress => $"{Line1} {Line2}, {Barangay}, {City}, {Province}, {PostalCode}";
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public required string Province { get; set; }
        public required string City { get; set; }
        public required string Barangay { get; set; }
        public required string PostalCode { get; set; }
        public required bool IsPrimary { get; set; }
        public required AddressType Type { get; set; }
        public required Status Status { get; set; }
        public required string LastModifiedBy { get; set; }
        public required DateTime LastModifiedAtUtc { get; set; }
    }
}
