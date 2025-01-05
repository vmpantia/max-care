using FluentValidation;
using MC.Core.Members.Commands;
using MC.Shared.Models.Enumerations;

namespace MC.Core.Members.Validators
{
    public class CreateMemberValidator : AbstractValidator<CreateMemberCommand>
    {
        public CreateMemberValidator()
        {
            RuleFor(prop => prop.FirstName)
                .NotEmpty();
            RuleFor(prop => prop.LastName)
                .NotEmpty();
            RuleFor(prop => prop.Gender)
                .NotNull();
            RuleFor(prop => prop.Birthdate)
                .NotNull()
                .Must(value => value < DateTime.Today)
                .WithMessage("Birthdate must be past date.");
            RuleFor(prop => prop.GroupId)
                .Null()
                .When(prop => prop.Type == MemberType.Individual)
                .WithMessage($"Group ID must be no value when member type is {MemberType.Individual}.");
            RuleFor(prop => prop.GroupId)
                .NotNull()
                .When(prop => prop.Type == MemberType.Group)
                .WithMessage($"Group ID is required when member type is {MemberType.Group}.");
        }
    }
}
