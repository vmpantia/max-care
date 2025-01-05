namespace MC.Infrastructure.Models.Interfaces
{
    public interface ICreatableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAtUtc { get; set; }
    }
}
