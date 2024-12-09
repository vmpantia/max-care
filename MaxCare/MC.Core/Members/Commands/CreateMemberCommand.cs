using MC.Shared.Models.Dtos.Members;
using MC.Shared.Models.Enumerations;
using MC.Shared.Results;
using MediatR;

namespace MC.Core.Members.Commands
{
    public class CreateMemberCommand : IRequest<Result<MemberDto>>
    {
        public CreateMemberCommand(CreateMemberDto dto)
        {
            GroupId = dto.GroupId;
            FirstName = dto.FirstName.Trim();
            MiddleName = dto.MiddleName?.Trim();
            LastName = dto.LastName.Trim();
            Gender = dto.Gender;
            Birthdate = dto.Birthdate.Date;
            Type = dto.Type;
        }

        public Guid? GroupId { get; init; }
        public string FirstName { get; init; }
        public string? MiddleName { get; init; }
        public string LastName { get; init; }
        public Gender Gender { get; init; }
        public DateTime Birthdate { get; init; }
        public MemberType Type { get; init; }
    }
}
