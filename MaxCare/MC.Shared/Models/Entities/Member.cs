using MC.Shared.Models.Enumerations;
using MC.Shared.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MC.Shared.Models.Entities
{
    public class Member : IMaintainableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid? GroupId { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthdate { get; set; }
        public MemberType Type { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string? EditedBy { get; set; }
        public DateTime? EditedAtUtc { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAtUtc { get; set; }

        [NotMapped]
        public virtual Group Group { get; set; }
    }
}
