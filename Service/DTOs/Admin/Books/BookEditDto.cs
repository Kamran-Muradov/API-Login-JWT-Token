using FluentValidation;

namespace Service.DTOs.Admin.Books
{
    public class BookEditDto
    {
        public string Title { get; set; }
    }

    public class BookEditDtoValidator : AbstractValidator<BookEditDto>
    {
        public BookEditDtoValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty()
                .WithMessage("Title is required")
                .MaximumLength(50)
                .WithMessage("Title cannot exceed 50 characters");
        }
    }
}
