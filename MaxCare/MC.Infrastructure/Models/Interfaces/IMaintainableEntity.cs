using MC.Infrastructure.Models.Interfaces;
using MC.Shared.Models.Enumerations;

namespace MC.Infrastructure.Models.Interfaces
{
    public interface IMaintainableEntity :
        ICreatableEntity,
        IEditableEntity,
        IDeletableEntity
    {
        public Guid Id { get; set; }
        public Status Status { get; set; }
    }
}
