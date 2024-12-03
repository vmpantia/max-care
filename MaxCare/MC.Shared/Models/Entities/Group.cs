using MC.Shared.Models.Enumerations;
using MC.Shared.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MC.Shared.Models.Entities
{
    public class Group : IMaintainableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
        public string? EditedBy { get; set; }
        public DateTime? EditedAtUtc { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAtUtc { get; set; }

        [NotMapped]
        public virtual ICollection<Member> Members { get; set; }
    }
}
