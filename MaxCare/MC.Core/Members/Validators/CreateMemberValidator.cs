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
                .NotNull()
                .NotEmpty();
            RuleFor(prop => prop.LastName)
                .NotNull()
                .NotEmpty();
            RuleFor(prop => prop.Gender)
                .NotNull();
            RuleFor(prop => prop.Birthdate)
                .Must(value => value < DateTime.Today)
                .WithMessage("Birthdate must be past date.");
            RuleFor(prop => prop.GroupId)
                .Must(value => value is null)
                .When(prop => prop.Type == MemberType.Individual)
                .WithMessage($"Group ID must be no value when member type is {MemberType.Individual}.");
            RuleFor(prop => prop.GroupId)
                .Must(value => value is not null)
                .When(prop => prop.Type == MemberType.Group)
                .WithMessage($"Group ID is required when member type is {MemberType.Group}.");
        }
    }
}
