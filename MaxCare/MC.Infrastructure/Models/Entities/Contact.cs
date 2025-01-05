using MC.Infrastructure.Models.Interfaces;
using MC.Shared.Models.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace MC.Infrastructure.Models.Entities
{
    public class Contact : IMaintainableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
        public ResourceType ResourceType { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
        public bool IsPrimary { get; set; }
        public ContactType Type { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string? EditedBy { get; set; }
        public DateTime? EditedAtUtc { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAtUtc { get; set; }
    }
}
