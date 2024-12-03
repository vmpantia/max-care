using MC.Shared.Models.Enumerations;
using MC.Shared.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MC.Shared.Models.Entities
{
    public class Address : IMaintainableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string Barangay { get; set; }
        public string PostalCode { get; set; }
        public bool IsPrimary { get; set; }
        public AddressType Type { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string? EditedBy { get; set; }
        public DateTime? EditedAtUtc { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
