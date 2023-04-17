using FluentValidation;

namespace Application.AuthorsCQRS.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public void UpdateAuthorCValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(50).WithMessage("Author name must not exceed 50 characters.");

            RuleFor(x => x.Bio)
                .NotEmpty().WithMessage("Bio is required.")
                .MaximumLength(500).WithMessage("Bio must not exceed 500 characters.");
        }
    }
}
