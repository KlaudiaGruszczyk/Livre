using FluentValidation;

namespace Application.AuthorsCQRS.Commands.UpdateAuthorName
{
    public class UpdateAuthorNameCommandValidator : AbstractValidator<UpdateAuthorNameCommand>
    {
        public void UpdateAuthorNameValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(50).WithMessage("Author name must not exceed 50 characters.");

        }
    }
}
