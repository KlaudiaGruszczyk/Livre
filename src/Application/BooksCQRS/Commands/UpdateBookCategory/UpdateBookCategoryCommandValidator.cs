using FluentValidation;

namespace Application.BooksCQRS.Commands.UpdateBookCategory
{
    public class UpdateBookCategoryCommandValidator : AbstractValidator<UpdateBookCategoryCommand>
    {
        public void UpdateBookCategoryValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull()
                .WithMessage("BookId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");

        }
    }
}
