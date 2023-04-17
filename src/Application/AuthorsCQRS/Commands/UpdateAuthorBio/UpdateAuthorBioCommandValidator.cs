using FluentValidation;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorBio
{
    public class UpdateAuthorBioCommandValidator : AbstractValidator<UpdateAuthorBioCommand>
    {
        public void UpdateAuthorBioValidator ()
        {
            RuleFor(x => x.Bio)
            .NotEmpty().WithMessage("Bio is required.")
            .MaximumLength(500).WithMessage("Bio must not exceed 500 characters.");
        }
    }
}
