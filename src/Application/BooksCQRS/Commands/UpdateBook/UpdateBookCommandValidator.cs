using FluentValidation;

namespace Application.BooksCQRS.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");

            RuleFor(x => x.AuthorName)
                .NotEmpty().WithMessage("Author name is required.")
                .MaximumLength(50).WithMessage("Author name must not exceed 50 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");

            RuleFor(x => x.PublishedDate)
                .NotEmpty().WithMessage("Published date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Published date cannot be in the future.");

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Category is required.")
                .MaximumLength(50).WithMessage("Category must not exceed 50 characters.");

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage("Publisher is required.")
                .MaximumLength(50).WithMessage("Publisher must not exceed 50 characters.");
        }
    }
}
