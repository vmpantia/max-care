using MC.Shared.Models.Enumerations;

namespace MC.Shared.Models.Dtos.Members
{
    public class CreateMemberDto
    {
        public required Guid? GroupId { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required Gender Gender { get; set; }
        public required DateTime Birthdate { get; set; }
        public required MemberType Type { get; set; }
    }
}
