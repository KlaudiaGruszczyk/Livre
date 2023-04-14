using FluentValidation;

namespace Application.BooksCQRS.Commands.UpdateBookPublisher
{
    public class UpdateBookPublisherCommandValidator : AbstractValidator<UpdateBookPublisherCommand>
    {
        public void UpdateBookPublisherValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull()
                .WithMessage("BookId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage("Publisher is required.")
                .MaximumLength(100).WithMessage("Publisher must not exceed 100 characters.");

        }
    }
}
