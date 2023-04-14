using FluentValidation;

namespace Application.BooksCQRS.Commands.UpdateBookDescription
{
    public class UpdateBookDescriptionCommandValidator : AbstractValidator<UpdateBookDescriptionCommand>
    {
        public void UpdateBookDescriptionValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull()
                .WithMessage("BookId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

        }
    }
}
