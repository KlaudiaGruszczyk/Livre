using FluentValidation;

namespace Application.BooksCQRS.Commands.UpdateBookTitle
{
    public class UpdateBookTitleCommandValidator : AbstractValidator<UpdateBookTitleCommand>
    {
        public void UpdateBookTitleValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull()
                .WithMessage("BookId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

        }
    }
}
