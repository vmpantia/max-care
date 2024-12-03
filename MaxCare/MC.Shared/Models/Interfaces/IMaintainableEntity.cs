using MC.Shared.Models.Enumerations;

namespace MC.Shared.Models.Interfaces
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
