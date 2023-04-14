using FluentValidation;

namespace Application.BooksCQRS.Commands.UpdateBookAuthor
{
    public class UpdateBookAuthorNameCommandValidator : AbstractValidator<UpdateBookAuthorNameCommand>
    {
        public void UpdateBookAuthorNameValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull()
                .WithMessage("BookId cannot be empty or null and must be a valid Guid.");

            RuleFor(x => x.Author)
                .NotNull().NotEmpty().WithMessage("Author cannot be empty or null.")
                .MaximumLength(50).WithMessage("Author can't be longer than 50 characters.");
            
        }
    }
}
