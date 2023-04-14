using FluentValidation;

namespace Application.BooksCQRS.Commands.UpdateBookPublishedDate
{
    public class UpdateBookPublishedDateCommandValidator : AbstractValidator<UpdateBookPublishedDateCommand>
    {
        public void UpdateBookPublishedDateValidator()
        {
            RuleFor(x => x.BookId).NotEmpty().NotNull()
              .WithMessage("BookId cannot be empty or null and must be a valid Guid.");



            RuleFor(x => x.PublishedDate).LessThan(p => DateTime.Now)
              .WithMessage("PublishedDate cannot be in the future.")
              .NotEmpty().NotNull()
              .WithMessage("Published Date shouldn't be empty");

        
        }
    }
}
